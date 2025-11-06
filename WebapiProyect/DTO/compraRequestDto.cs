namespace WebapiProyect.DTO
{
    public class compraRequestDto
    {

        public long? ProveedorId { get; set; }
        public DateOnly Fecha { get; set; }
        public decimal Total { get; set; }
        public string? TipoPago { get; set; }

        public List<DetalleCompraRequestDto> DetalleCompras { get; set; } = new List<DetalleCompraRequestDto>();

    }
}
