using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            //RemisionDets = new HashSet<RemisionDet>();
        }

        public int IdTicket { get; set; }
        public int IdCaseTicket { get; set; }
        public string TipoTicket { get; set; } = null!;
        public DateTime FechaTicket { get; set; }
        public string EstadoTicket { get; set; } = null!;
        public int IdUsuario { get; set; }
        public int? IdServicio { get; set; }
        public int? IdRepuesto { get; set; }
        public int? IdInforme { get; set; }

       //public virtual Informe? IdInformeNavigation { get; set; }
       //public virtual Repuesto? IdRepuestoNavigation { get; set; }
       //public virtual Servicio? IdServicioNavigation { get; set; }
       //public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
       //public virtual ICollection<RemisionDet> RemisionDets { get; set; }
    }
}
