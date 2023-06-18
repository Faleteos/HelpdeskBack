namespace HELPDESKPC.ModelsView
{
    public class InformesMV
    {
        public int IdInforme { get; set; }
        public string TipoInforme { get; set; } = null!;
        public DateTime FechaInforme { get; set; }
        public string DescInforme { get; set; } = null!;
        public string EstadoInforme { get; set; } = null!;
    }
}
