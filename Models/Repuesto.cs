using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Repuesto
    {
        public Repuesto()
        {
           // Tickets = new HashSet<Ticket>();
        }

        public int IdRepuesto { get; set; }
        public string TipoRep { get; set; } = null!;
        public string? Marca { get; set; }
        public string CapRep { get; set; } = null!;
        public decimal ValorRep { get; set; }
        public int StockRep { get; set; }

        //public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
