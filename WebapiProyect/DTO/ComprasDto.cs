namespace WebapiProyect.DTO
{
    public class ComprasDto
    {
        public long Id { get; set; }
        public DateOnly Fecha { get; set; }
        public string Proveedor { get; set; }
        public string tipoPago { get; set; }
        public decimal total {  get; set; }
        public long ProveedorId { get; set; }
        public List<DetalleCompraRequestDto> DetalleCompras { get; set; } = new List<DetalleCompraRequestDto>();

    }
}
