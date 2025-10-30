namespace WebapiProyect.DTO
{
    public class HerramientaDto
    {
        public long IdHerramienta { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Estado { get; set; }
        public DateOnly? FechaAdquisicion { get; set; }
        public Decimal CantidadDisponible { get; set; }
    }
}
