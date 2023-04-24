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
    public class InformesController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public InformesController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/Informes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Informe>>> GetInformes()
        {
          if (_context.Informes == null)
          {
              return NotFound();
          }
            return await _context.Informes.ToListAsync();
        }

        // GET: api/Informes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Informe>> GetInforme(int id)
        {
          if (_context.Informes == null)
          {
              return NotFound();
          }
            var informe = await _context.Informes.FindAsync(id);

            if (informe == null)
            {
                return NotFound();
            }

            return informe;
        }

        // PUT: api/Informes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInforme(int id, Informe informe)
        {
            if (id != informe.IdInforme)
            {
                return BadRequest();
            }

            _context.Entry(informe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformeExists(id))
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

        // POST: api/Informes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Informe>> PostInforme(Informe informe)
        {
          if (_context.Informes == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.Informes'  is null.");
          }
            _context.Informes.Add(informe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InformeExists(informe.IdInforme))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInforme", new { id = informe.IdInforme }, informe);
        }

        // DELETE: api/Informes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInforme(int id)
        {
            if (_context.Informes == null)
            {
                return NotFound();
            }
            var informe = await _context.Informes.FindAsync(id);
            if (informe == null)
            {
                return NotFound();
            }

            _context.Informes.Remove(informe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformeExists(int id)
        {
            return (_context.Informes?.Any(e => e.IdInforme == id)).GetValueOrDefault();
        }
    }
}
