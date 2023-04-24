using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Persona
    {
        public Persona()
        {
            //Adcrs = new HashSet<Adcr>();
            //Usuarios = new HashSet<Usuario>();
        }

        public int IdPersona { get; set; }
        public string TipoDoc { get; set; } = null!;
        public long NumDoc { get; set; }
        public string PNombre { get; set; } = null!;
        public string? SNombre { get; set; }
        public string PApellido { get; set; } = null!;
        public string SApellido { get; set; } = null!;
        public long NumCel { get; set; }
        public string Email { get; set; } = null!;

        //public virtual ICollection<Adcr> Adcrs { get; set; }
        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
