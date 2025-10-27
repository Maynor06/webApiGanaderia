namespace WebapiProyect.DTO
{
    public class SuplementosDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string tipo { get; set; }
        public string Nutrientes { get; set; }
        public string stock { get; set; }
        public DateOnly FechaVencimiento { get; set; }
    }
}
