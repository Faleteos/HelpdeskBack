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
    public class RemisionCabsController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public RemisionCabsController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/RemisionCabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RemisionCab>>> GetRemisionCabs()
        {
          if (_context.RemisionCabs == null)
          {
              return NotFound();
          }
            return await _context.RemisionCabs.ToListAsync();
        }

        // GET: api/RemisionCabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RemisionCab>> GetRemisionCab(int id)
        {
          if (_context.RemisionCabs == null)
          {
              return NotFound();
          }
            var remisionCab = await _context.RemisionCabs.FindAsync(id);

            if (remisionCab == null)
            {
                return NotFound();
            }

            return remisionCab;
        }

        // PUT: api/RemisionCabs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemisionCab(int id, RemisionCab remisionCab)
        {
            if (id != remisionCab.IdRemision)
            {
                return BadRequest();
            }

            _context.Entry(remisionCab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemisionCabExists(id))
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

        // POST: api/RemisionCabs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RemisionCab>> PostRemisionCab(RemisionCab remisionCab)
        {
          if (_context.RemisionCabs == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.RemisionCabs'  is null.");
          }
            _context.RemisionCabs.Add(remisionCab);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RemisionCabExists(remisionCab.IdRemision))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRemisionCab", new { id = remisionCab.IdRemision }, remisionCab);
        }

        // DELETE: api/RemisionCabs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemisionCab(int id)
        {
            if (_context.RemisionCabs == null)
            {
                return NotFound();
            }
            var remisionCab = await _context.RemisionCabs.FindAsync(id);
            if (remisionCab == null)
            {
                return NotFound();
            }

            _context.RemisionCabs.Remove(remisionCab);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RemisionCabExists(int id)
        {
            return (_context.RemisionCabs?.Any(e => e.IdRemision == id)).GetValueOrDefault();
        }
    }
}
