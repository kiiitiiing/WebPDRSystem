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
    public class DMFQNController : ControllerBase
    {
        private readonly WebPDRContext _context;

        public DMFQNController(WebPDRContext context)
        {
            _context = context;
        }

        // GET: api/QnformTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qnform>>> GetQnformTable()
        {
            return await _context.Qnform
                .Include(x => x.ClinicalParametersQn)
                .ToListAsync();
        }

        // GET: api/QnformTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qnform>> GetQnformTable(int id)
        {
            var qnformTable = await _context.Qnform.FindAsync(id);

            if (qnformTable == null)
            {
                return NotFound();
            }

            return qnformTable;
        }

        // PUT: api/QnformTables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQnformTable(int id, Qnform qnformTable)
        {
            if (id != qnformTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(qnformTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QnformTableExists(id))
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

        // POST: api/QnformTables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Qnform>> PostQnformTable(Qnform qnformTable)
        {
            qnformTable.CreatedAt = DateTime.Now;
            qnformTable.UpdatedAt = DateTime.Now;
            _context.Qnform.Add(qnformTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQnformTable", new { id = qnformTable.Id }, qnformTable);
        }

        // DELETE: api/QnformTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Qnform>> DeleteQnformTable(int id)
        {
            var qnformTable = await _context.Qnform.FindAsync(id);
            if (qnformTable == null)
            {
                return NotFound();
            }

            _context.Qnform.Remove(qnformTable);
            await _context.SaveChangesAsync();

            return qnformTable;
        }

        private bool QnformTableExists(int id)
        {
            return _context.Qnform.Any(e => e.Id == id);
        }
    }
}