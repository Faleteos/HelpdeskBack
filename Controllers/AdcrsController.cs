using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HELPDESKPC.Models;

namespace HELPDESKPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdcrsController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public AdcrsController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/Adcrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adcr>>> GetAdcrs()
        {
          if (_context.Adcrs == null)
          {
              return NotFound();
          }
            return await _context.Adcrs.ToListAsync();
        }

        // GET: api/Adcrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adcr>> GetAdcr(int id)
        {
          if (_context.Adcrs == null)
          {
              return NotFound();
          }
            var adcr = await _context.Adcrs.FindAsync(id);

            if (adcr == null)
            {
                return NotFound();
            }

            return adcr;
        }

        // PUT: api/Adcrs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdcr(int id, Adcr adcr)
        {
            if (id != adcr.IdAdcr)
            {
                return BadRequest();
            }

            _context.Entry(adcr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdcrExists(id))
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

        // POST: api/Adcrs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adcr>> PostAdcr(Adcr adcr)
        {
          if (_context.Adcrs == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.Adcrs'  is null.");
          }
            _context.Adcrs.Add(adcr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdcr", new { id = adcr.IdAdcr }, adcr);
        }

        // DELETE: api/Adcrs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdcr(int id)
        {
            if (_context.Adcrs == null)
            {
                return NotFound();
            }
            var adcr = await _context.Adcrs.FindAsync(id);
            if (adcr == null)
            {
                return NotFound();
            }

            _context.Adcrs.Remove(adcr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdcrExists(int id)
        {
            return (_context.Adcrs?.Any(e => e.IdAdcr == id)).GetValueOrDefault();
        }
    }
}
