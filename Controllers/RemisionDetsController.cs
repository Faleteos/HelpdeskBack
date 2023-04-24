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
    public class RemisionDetsController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public RemisionDetsController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/RemisionDets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RemisionDet>>> GetRemisionDets()
        {
          if (_context.RemisionDets == null)
          {
              return NotFound();
          }
            return await _context.RemisionDets.ToListAsync();
        }

        // GET: api/RemisionDets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RemisionDet>> GetRemisionDet(int id)
        {
          if (_context.RemisionDets == null)
          {
              return NotFound();
          }
            var remisionDet = await _context.RemisionDets.FindAsync(id);

            if (remisionDet == null)
            {
                return NotFound();
            }

            return remisionDet;
        }

        // PUT: api/RemisionDets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemisionDet(int id, RemisionDet remisionDet)
        {
            if (id != remisionDet.IdDetalle)
            {
                return BadRequest();
            }

            _context.Entry(remisionDet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemisionDetExists(id))
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

        // POST: api/RemisionDets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RemisionDet>> PostRemisionDet(RemisionDet remisionDet)
        {
          if (_context.RemisionDets == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.RemisionDets'  is null.");
          }
            _context.RemisionDets.Add(remisionDet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RemisionDetExists(remisionDet.IdDetalle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRemisionDet", new { id = remisionDet.IdDetalle }, remisionDet);
        }

        // DELETE: api/RemisionDets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemisionDet(int id)
        {
            if (_context.RemisionDets == null)
            {
                return NotFound();
            }
            var remisionDet = await _context.RemisionDets.FindAsync(id);
            if (remisionDet == null)
            {
                return NotFound();
            }

            _context.RemisionDets.Remove(remisionDet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RemisionDetExists(int id)
        {
            return (_context.RemisionDets?.Any(e => e.IdDetalle == id)).GetValueOrDefault();
        }
    }
}
