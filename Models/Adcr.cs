using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Adcr
    {
        public int IdAdcr { get; set; }
        public string Pais { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string? Barrio { get; set; }
        public string Direccion { get; set; } = null!;
        public int IdPersona { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; } = null!;
    }
}
