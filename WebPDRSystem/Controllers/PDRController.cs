using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models;

namespace PDRSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDRController : ControllerBase
    {
        private readonly WebPDRContext _context;

        public PDRController(WebPDRContext context)
        {
            _context = context;
        }

        // GET: api/PDR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pdr>>> GetPDRP()
        {
            return await _context.Pdr
                .Include(x=>x.PatientNavigation)
                .Include(x=>x.GuardianNavigation)
                .Include(x => x.SymptomsContacts)
                .Include(x=>x.Discharge)
                .Include(x=>x.Referral)
                .ToListAsync();
        }

        // GET: api/PDR/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pdr>> GetPDRModel(int id)
        {
            var pdrModel = await _context.Pdr.FindAsync(id);

            if (pdrModel == null)
            {
                return NotFound();
            }

            return pdrModel;
        }

        // PUT: api/PDR/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPDRModel(int id, Pdr pdrModel)
        {
            if (id != pdrModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pdrModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PDRModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PDR
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pdr>> PostPDRModel(Pdr pdrModel)
        {
            pdrModel.PatientNavigation.UpdatedAt = DateTime.Now;
            pdrModel.GuardianNavigation.UpdatedAt = DateTime.Now;
            pdrModel.UpdatedAt = DateTime.Now;
            if (_context.Pdr.Any(x => x.Id == pdrModel.Id))
                _context.Update(pdrModel);
            else
            {
                pdrModel.GuardianNavigation.CreatedAt = DateTime.Now;
                pdrModel.PatientNavigation.CreatedAt = DateTime.Now;
                pdrModel.CreatedAt = DateTime.Now;
                _context.Pdr.Add(pdrModel);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPDRModel", new { id = pdrModel.Id }, pdrModel);
        }

        // DELETE: api/PDR/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pdr>> DeletePDRModel(int id)
        {
            var pdrModel = await _context.Pdr.FindAsync(id);
            if (pdrModel == null)
            {
                return NotFound();
            }

            _context.Pdr.Remove(pdrModel);
            await _context.SaveChangesAsync();

            return pdrModel;
        }

        private bool PDRModelExists(int id)
        {
            return _context.Pdr.Any(e => e.Id == id);
        }
    }
}