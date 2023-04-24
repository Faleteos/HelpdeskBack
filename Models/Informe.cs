using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Informe
    {
        public Informe()
        {
            //Tickets = new HashSet<Ticket>();
        }

        public int IdInforme { get; set; }
        public string TipoInforme { get; set; } = null!;
        public DateTime FechaInforme { get; set; }
        public string DescInforme { get; set; } = null!;
        public string EstadoInforme { get; set; } = null!;

        //public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
