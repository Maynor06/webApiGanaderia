using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface ICapacitacion
    {
        Task<List<CapacitacionDto>> GetAllCapacitaciones();
        Task<Capacitacion> CreateCapacitacion(Capacitacion capacitacion);
        Task<Capacitacion> UpdateCapacitacion(long id, Capacitacion capacitacion);
    }
}
