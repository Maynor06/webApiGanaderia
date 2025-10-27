namespace WebapiProyect.DTO
{
    public class PlanillaDto
    {
        public int Id { get; set; }
        public string? NombreEmpleado { get; set; }
        public string? CargoEmpleado { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
        public decimal SalarioNeto { get; set; }
    }
}
