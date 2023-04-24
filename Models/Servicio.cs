using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            //Tickets = new HashSet<Ticket>();
        }

        public int IdServicio { get; set; }
        public string NombServ { get; set; } = null!;
        public decimal ValorServicio { get; set; }
        public string EstadoServicio { get; set; } = null!;

        //public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
