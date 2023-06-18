﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HELPDESKPC.Models;
using HELPDESKPC.ModelsView;

namespace HELPDESKPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public PersonasController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonasMV>>> GetPersonas()
        {
            //if (_context.Personas == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Personas.ToListAsync();
            var personas = await _context.Personas.ToListAsync();
            var adcrs = await _context.Adcrs.ToListAsync();

            var query = from per in personas
                        join adc in adcrs on per.IdPersona equals adc.IdPersona
                        select new PersonasMV
                        {
                            IdPersona = per.IdPersona,
                            TipoDoc = per.TipoDoc,
                            NumDoc = per.NumDoc,
                            PNombre = per.PNombre,
                            SNombre = per.SNombre,
                            PApellido = per.PApellido,
                            SApellido = per.SApellido,
                            NumCel = per.NumCel,
                            Email = per.Email,
                            Pais = adc.Pais,
                            Departamento = adc.Departamento,
                            Ciudad = adc.Ciudad,
                            Barrio = adc.Barrio,
                            Direccion = adc.Direccion,
                        };

            return query.ToList(); 
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
          if (_context.Personas == null)
          {
              return NotFound();
          }
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.IdPersona)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
          if (_context.Personas == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.Personas'  is null.");
          }
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.IdPersona }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            if (_context.Personas == null)
            {
                return NotFound();
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return (_context.Personas?.Any(e => e.IdPersona == id)).GetValueOrDefault();
        }
    }
}
