using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IEmpleadoService
    {

        Task<EmpleadoDTO?> GetEmpleadoById(long id);
        Task<Empleado> CreateEmpleado(Empleado empleado);
        Task<Empleado?> UpdateEmpleado(long id, Empleado empleado);
        Task<bool> DeleteEmpleado(long id);
        Task<List<EmpleadoDTO>> GetAllEmpleados();
        Task<List<EmpleadoDTO>> GetEmpleadosByCargoId(long cargoId);
    }
}
