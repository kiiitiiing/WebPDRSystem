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
    public class DMFQDController : ControllerBase
    {
        private readonly WebPDRContext _context;

        public DMFQDController(WebPDRContext context)
        {
            _context = context;
        }

        // GET: api/DMFQD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qdform>>> GetQdformTable()
        {
            return await _context.Qdform
                .ToListAsync();
        }

        // GET: api/DMFQD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qdform>> GetQdformTable(int id)
        {
            var qdformTable = await _context.Qdform.FindAsync(id);

            if (qdformTable == null)
            {
                return NotFound();
            }

            return qdformTable;
        }

        // PUT: api/DMFQD/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQdformTable(int id, Qdform qdformTable)
        {
            if (id != qdformTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(qdformTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QdformTableExists(id))
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

        // POST: api/DMFQD
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Qdform>> PostQdformTable(Qdform qdformTable)
        {
            qdformTable.CreatedAt = DateTime.Now;
            qdformTable.UpdatedAt = DateTime.Now;
            _context.Qdform.Add(qdformTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQdformTable", new { id = qdformTable.Id }, qdformTable);
        }

        // DELETE: api/DMFQD/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Qdform>> DeleteQdformTable(int id)
        {
            var qdformTable = await _context.Qdform.FindAsync(id);
            if (qdformTable == null)
            {
                return NotFound();
            }

            _context.Qdform.Remove(qdformTable);
            await _context.SaveChangesAsync();

            return qdformTable;
        }

        private bool QdformTableExists(int id)
        {
            return _context.Qdform.Any(e => e.Id == id);
        }
    }
}