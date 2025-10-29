using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IMedicamento
    {
        Task<List<DTO.MedicamentosDto>> getMedicamentosConCantidadYFechaVencimiento();
        Task<Medicamento> CreateMedicamentoAsync(Medicamento medicamento);
        Task<Medicamento> ActualizarMedicamento(long id, Medicamento medicamento);

    }
}
