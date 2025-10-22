using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IEmpleadoService
    {

        Task<Empleado?> GetEmpleadoById(long id);
        Task<Empleado> CreateEmpleado(Empleado empleado);
        Task<Empleado?> UpdateEmpleado(long id, Empleado empleado);
        Task<bool> DeleteEmpleado(long id);
        Task<List<Empleado>> GetAllEmpleados();
        Task<List<Empleado>> GetEmpleadosByCargoId(long cargoId);
    }
}
