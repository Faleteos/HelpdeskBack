using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            //Tickets = new HashSet<Ticket>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string EstadoUsuario { get; set; } = null!;
        public int IdPersona { get; set; }
        public int IdRol { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; } = null!;
        //public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
