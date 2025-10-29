namespace WebapiProyect.DTO
{
    public class MedicamentosDto
    {

        public long IdMedicamento { get; set; }
        public string? Nombre { get; set; }
        public string? Laboratorio { get; set; }
        public string? DosisRecomendada { get; set; }
        public decimal cantidadDisponible { get; set; }
        public string fechaVencimiento { get; set; }

    }
}
