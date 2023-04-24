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
    public class RepuestoesController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public RepuestoesController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/Repuestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repuesto>>> GetRepuestos()
        {
          if (_context.Repuestos == null)
          {
              return NotFound();
          }
            return await _context.Repuestos.ToListAsync();
        }

        // GET: api/Repuestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repuesto>> GetRepuesto(int id)
        {
          if (_context.Repuestos == null)
          {
              return NotFound();
          }
            var repuesto = await _context.Repuestos.FindAsync(id);

            if (repuesto == null)
            {
                return NotFound();
            }

            return repuesto;
        }

        // PUT: api/Repuestoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepuesto(int id, Repuesto repuesto)
        {
            if (id != repuesto.IdRepuesto)
            {
                return BadRequest();
            }

            _context.Entry(repuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepuestoExists(id))
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

        // POST: api/Repuestoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repuesto>> PostRepuesto(Repuesto repuesto)
        {
          if (_context.Repuestos == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.Repuestos'  is null.");
          }
            _context.Repuestos.Add(repuesto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepuestoExists(repuesto.IdRepuesto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepuesto", new { id = repuesto.IdRepuesto }, repuesto);
        }

        // DELETE: api/Repuestoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepuesto(int id)
        {
            if (_context.Repuestos == null)
            {
                return NotFound();
            }
            var repuesto = await _context.Repuestos.FindAsync(id);
            if (repuesto == null)
            {
                return NotFound();
            }

            _context.Repuestos.Remove(repuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepuestoExists(int id)
        {
            return (_context.Repuestos?.Any(e => e.IdRepuesto == id)).GetValueOrDefault();
        }
    }
}
