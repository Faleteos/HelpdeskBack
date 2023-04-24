using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class RemisionCab
    {
        public RemisionCab()
        {
            //RemisionDets = new HashSet<RemisionDet>();
        }

        public int IdRemision { get; set; }
        public DateTime FechaRemision { get; set; }
        public string EstadoRemision { get; set; } = null!;
        public int NumTicket { get; set; }

        //public virtual ICollection<RemisionDet> RemisionDets { get; set; }
    }
}
