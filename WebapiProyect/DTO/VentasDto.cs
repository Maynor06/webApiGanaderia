namespace WebapiProyect.DTO
{
    public class VentasDto
    {
        public long IdVenta { get; set; }
        public string NombreCliente { get; set; }
        public DateOnly? Fecha { get; set; }
        public decimal? Total { get; set; }
        public string? TipoPago { get; set; }
    }
}
