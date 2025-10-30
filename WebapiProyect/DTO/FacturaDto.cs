namespace WebapiProyect.DTO
{
    public class FacturaDto
    {
        public long IdFactura { get; set; }
        public string? Numero { get; set; }
        public DateOnly? Fecha { get; set; }
        public string  Origen { get; set; }
        public long? ProveedorId { get; set; }
        public decimal? MontoTotal { get; set; }
        public decimal? MontoPagado { get; set; }
    }
}
