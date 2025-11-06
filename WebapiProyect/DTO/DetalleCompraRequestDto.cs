namespace WebapiProyect.DTO
{
    public class DetalleCompraRequestDto
    {
        public long DetalleCompraId { get; set; }
        public long ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}
