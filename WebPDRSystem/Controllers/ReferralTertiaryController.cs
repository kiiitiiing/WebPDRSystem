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
    public class ReferralTertiaryController : ControllerBase
    {
        private readonly WebPDRContext _context;

        public ReferralTertiaryController(WebPDRContext context)
        {
            _context = context;
        }

        // GET: api/ReferralTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Referral>>> GetReferralTable()
        {
            return await _context.Referral.ToListAsync();
        }

        // GET: api/ReferralTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Referral>> GetReferralTable(int id)
        {
            var referralTable = await _context.Referral.FindAsync(id);

            if (referralTable == null)
            {
                return NotFound();
            }

            return referralTable;
        }

        // PUT: api/ReferralTables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferralTable(int id, Referral referralTable)
        {
            if (id != referralTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(referralTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralTableExists(id))
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

        // POST: api/ReferralTables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Referral>> PostReferralTable(Referral referralTable)
        {
            _context.Referral.Add(referralTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferralTable", new { id = referralTable.Id }, referralTable);
        }

        // DELETE: api/ReferralTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Referral>> DeleteReferralTable(int id)
        {
            var referralTable = await _context.Referral.FindAsync(id);
            if (referralTable == null)
            {
                return NotFound();
            }

            _context.Referral.Remove(referralTable);
            await _context.SaveChangesAsync();

            return referralTable;
        }

        private bool ReferralTableExists(int id)
        {
            return _context.Referral.Any(e => e.Id == id);
        }
    }
}