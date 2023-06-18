namespace HELPDESKPC.ModelsView
{
    public class TicketsMV
    {
        public int IdTicket { get; set; }
        public int IdCaseTicket { get; set; }
        public string TipoTicket { get; set; } = null!;
        public DateTime FechaTicket { get; set; }
        public string EstadoTicket { get; set; } = null!;
        //public int IdUsuario { get; set; }
        //public int? IdServicio { get; set; }
        //public int? IdRepuesto { get; set; }
        //public int? IdInforme { get; set; }
        public int IdInforme { get; set; }
        public string TipoInforme { get; set; } = null!;
        public DateTime FechaInforme { get; set; }
        public string DescInforme { get; set; } = null!;
        public string EstadoInforme { get; set; } = null!;
        public int IdServicio { get; set; }
        public string NombServ { get; set; } = null!;
        public decimal ValorServicio { get; set; }
        public string EstadoServicio { get; set; } = null!;
        public int IdRepuesto { get; set; }
        public string TipoRep { get; set; } = null!;
        public string? Marca { get; set; }
        public string CapRep { get; set; } = null!;
        public decimal ValorRep { get; set; }
        public int StockRep { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string EstadoUsuario { get; set; } = null!;
        public int IdPersona { get; set; }
        public int IdRol { get; set; }

    }
}
