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
    public class RolesUsuariosController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public RolesUsuariosController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/RolesUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolesUsuario>>> GetRolesUsuarios()
        {
          if (_context.RolesUsuarios == null)
          {
              return NotFound();
          }
            return await _context.RolesUsuarios.ToListAsync();
        }

        // GET: api/RolesUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolesUsuario>> GetRolesUsuario(int id)
        {
          if (_context.RolesUsuarios == null)
          {
              return NotFound();
          }
            var rolesUsuario = await _context.RolesUsuarios.FindAsync(id);

            if (rolesUsuario == null)
            {
                return NotFound();
            }

            return rolesUsuario;
        }

        // PUT: api/RolesUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolesUsuario(int id, RolesUsuario rolesUsuario)
        {
            if (id != rolesUsuario.IdRol)
            {
                return BadRequest();
            }

            _context.Entry(rolesUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesUsuarioExists(id))
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

        // POST: api/RolesUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolesUsuario>> PostRolesUsuario(RolesUsuario rolesUsuario)
        {
          if (_context.RolesUsuarios == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.RolesUsuarios'  is null.");
          }
            _context.RolesUsuarios.Add(rolesUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolesUsuarioExists(rolesUsuario.IdRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRolesUsuario", new { id = rolesUsuario.IdRol }, rolesUsuario);
        }

        // DELETE: api/RolesUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolesUsuario(int id)
        {
            if (_context.RolesUsuarios == null)
            {
                return NotFound();
            }
            var rolesUsuario = await _context.RolesUsuarios.FindAsync(id);
            if (rolesUsuario == null)
            {
                return NotFound();
            }

            _context.RolesUsuarios.Remove(rolesUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolesUsuarioExists(int id)
        {
            return (_context.RolesUsuarios?.Any(e => e.IdRol == id)).GetValueOrDefault();
        }
    }
}
