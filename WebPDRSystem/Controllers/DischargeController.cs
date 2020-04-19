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
    public class DischargeController : ControllerBase
    {
        private readonly WebPDRContext _context;

        public DischargeController(WebPDRContext context)
        {
            _context = context;
        }

        // GET: api/DischargeTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discharge>>> GetDischargeTable()
        {
            return await _context.Discharge.ToListAsync();
        }

        // GET: api/DischargeTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discharge>> GetDischargeTable(int id)
        {
            var dischargeTable = await _context.Discharge.FindAsync(id);

            if (dischargeTable == null)
            {
                return NotFound();
            }

            return dischargeTable;
        }

        // PUT: api/DischargeTables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDischargeTable(int id, Discharge dischargeTable)
        {
            if (id != dischargeTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(dischargeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DischargeTableExists(id))
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

        // POST: api/DischargeTables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Discharge>> PostDischargeTable(Discharge dischargeTable)
        {
            _context.Discharge.Add(dischargeTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDischargeTable", new { id = dischargeTable.Id }, dischargeTable);
        }

        // DELETE: api/DischargeTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Discharge>> DeleteDischargeTable(int id)
        {
            var dischargeTable = await _context.Discharge.FindAsync(id);
            if (dischargeTable == null)
            {
                return NotFound();
            }

            _context.Discharge.Remove(dischargeTable);
            await _context.SaveChangesAsync();

            return dischargeTable;
        }

        private bool DischargeTableExists(int id)
        {
            return _context.Discharge.Any(e => e.Id == id);
        }
    }
}