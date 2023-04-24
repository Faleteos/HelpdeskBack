using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class RemisionDet
    {
        public int IdDetalle { get; set; }
        public int PosDetalle { get; set; }
        public int IdRemision { get; set; }
        public int IdTicket { get; set; }

        //public virtual RemisionCab IdRemisionNavigation { get; set; } = null!;
        //public virtual Ticket IdTicketNavigation { get; set; } = null!;
    }
}
