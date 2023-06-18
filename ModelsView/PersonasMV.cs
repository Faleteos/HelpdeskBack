namespace HELPDESKPC.ModelsView
{
    public class PersonasMV
    {

        public int IdPersona { get; set; }
        public string TipoDoc { get; set; } = null!;
        public long NumDoc { get; set; }
        public string PNombre { get; set; } = null!;
        public string? SNombre { get; set; }
        public string PApellido { get; set; } = null!;
        public string SApellido { get; set; } = null!;
        public long NumCel { get; set; }
        public string Email { get; set; } = null!;
        //public int IdAdcr { get; set; }
        public string Pais { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string? Barrio { get; set; }
        public string Direccion { get; set; } = null!;
        //public int IdPersonaf { get; set; }
    }   
}
