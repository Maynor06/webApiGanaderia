using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IEstablo
    {
        Task<List<EstabloDto>> GetAllEstablosAsync();
        Task<Establo> CreateEstabloAsync(Establo establo);
        Task<Establo> UpdateEstabloAsync(long id, Establo establo);
    }
}
