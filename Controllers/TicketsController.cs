using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HELPDESKPC.Models;
using HELPDESKPC.ModelsView;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace HELPDESKPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly dbhelpdeskpcContext _context;

        public TicketsController(dbhelpdeskpcContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketsMV>>> GetTickets()
        {
            //if (_context.Tickets == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Tickets.ToListAsync();

            var tickets = await _context.Tickets.ToListAsync();
            var informes = await _context.Informes.ToListAsync();
            var repuestos = await _context.Repuestos.ToListAsync();
            var servicios = await _context.Servicios.ToListAsync();
            var usuarios = await _context.Usuarios.ToListAsync();

            var query = from tic in tickets
                        join inf in informes on tic.IdInforme equals inf.IdInforme into inf1
                        from inf2 in inf1.DefaultIfEmpty()
                        join rep in repuestos on tic.IdRepuesto equals rep.IdRepuesto into rep1
                        from rep2 in rep1.DefaultIfEmpty()
                        join ser in servicios on tic.IdServicio equals ser.IdServicio into ser1
                        from ser2 in ser1.DefaultIfEmpty()
                        join usr in usuarios on tic.IdUsuario equals usr.IdUsuario into usr1
                        from usr2 in usr1.DefaultIfEmpty()

                        select new TicketsMV
                        {
                            IdTicket = tic.IdTicket,
                            IdCaseTicket = tic.IdCaseTicket,
                            TipoTicket = tic.TipoTicket,
                            FechaTicket = tic.FechaTicket,
                            EstadoTicket = tic.EstadoTicket,
                            //IdInforme = inf2 == null? : inf2.IdInforme,
                            TipoInforme = inf2.TipoInforme, 
                            FechaInforme = inf2.FechaInforme,
                            DescInforme = inf2.DescInforme,
                            EstadoInforme = inf2.EstadoInforme,
                            IdServicio = ser2.IdServicio,
                            NombServ = ser2.NombServ,
                            ValorServicio = ser2.ValorServicio,
                            EstadoServicio = ser2.EstadoServicio,
                            IdRepuesto = rep2.IdRepuesto,
                            TipoRep = rep2.TipoRep,
                            Marca = rep2.Marca,
                            CapRep = rep2.CapRep,
                            ValorRep = rep2.ValorRep,
                            StockRep = rep2.StockRep,
                            IdUsuario = usr2.IdUsuario,
                            NombreUsuario = usr2.NombreUsuario,

                        };

            return query.ToList();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
          if (_context.Tickets == null)
          {
              return NotFound();
          }
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.IdTicket)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
          if (_context.Tickets == null)
          {
              return Problem("Entity set 'dbhelpdeskpcContext.Tickets'  is null.");
          }
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.IdTicket }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return (_context.Tickets?.Any(e => e.IdTicket == id)).GetValueOrDefault();
        }
    }
}
