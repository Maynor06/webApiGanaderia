namespace WebapiProyect.DTO
{
    public class CapacitacionDto
    {

        public long IdCapacitacion { get; set; }

        public string? NombreCapacitacion { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? nombreEmpleado { get; set; }

        public string? Tema { get; set; }
    }
}
