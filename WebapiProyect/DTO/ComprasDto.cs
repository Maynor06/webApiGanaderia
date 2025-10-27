namespace WebapiProyect.DTO
{
    public class ComprasDto
    {
        public long Id { get; set; }
        public DateOnly Fecha { get; set; }
        public string Proveedor { get; set; }
        public string tipoPago { get; set; }
        public decimal total {  get; set; }

    }
}
