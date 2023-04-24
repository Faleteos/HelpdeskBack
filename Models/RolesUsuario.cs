using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class RolesUsuario
    {
        public int IdRol { get; set; }
        public string TipoRol { get; set; } = null!;
        public int IdModulo { get; set; }
    }
}
