﻿using System;
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
    public class ModuloesController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public ModuloesController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/Moduloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulos()
        {
          if (_context.Modulos == null)
          {
              return NotFound();
          }
            return await _context.Modulos.ToListAsync();
        }

        // GET: api/Moduloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> GetModulo(int id)
        {
          if (_context.Modulos == null)
          {
              return NotFound();
          }
            var modulo = await _context.Modulos.FindAsync(id);

            if (modulo == null)
            {
                return NotFound();
            }

            return modulo;
        }

        // PUT: api/Moduloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(int id, Modulo modulo)
        {
            if (id != modulo.IdModulo)
            {
                return BadRequest();
            }

            _context.Entry(modulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuloExists(id))
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

        // POST: api/Moduloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modulo>> PostModulo(Modulo modulo)
        {
          if (_context.Modulos == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.Modulos'  is null.");
          }
            _context.Modulos.Add(modulo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModuloExists(modulo.IdModulo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModulo", new { id = modulo.IdModulo }, modulo);
        }

        // DELETE: api/Moduloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModulo(int id)
        {
            if (_context.Modulos == null)
            {
                return NotFound();
            }
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }

            _context.Modulos.Remove(modulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuloExists(int id)
        {
            return (_context.Modulos?.Any(e => e.IdModulo == id)).GetValueOrDefault();
        }
    }
}
