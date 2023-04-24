using System;
using System.Collections.Generic;

namespace HELPDESKPC.Models
{
    public partial class Modulo
    {
        public int IdModulo { get; set; }
        public string NameModul { get; set; } = null!;
        public string? Get { get; set; }
        public string? Getbyid { get; set; }
        public string? Post { get; set; }
        public string? Put { get; set; }
        public string? Mdelete { get; set; }
    }
}
