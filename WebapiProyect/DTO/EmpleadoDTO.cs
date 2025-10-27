namespace WebapiProyect.DTO
{
    public class EmpleadoDTO
    {
        public long ID { get; set; }
        public string? NombreCompleto { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public string? Cargo { get; set; }
        public DateOnly? FechaIngreso { get; set; }
        public string Antiguedad { get; set; }
        public decimal? Salario { get; set; }

    }
}
