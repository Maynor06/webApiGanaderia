using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IEspecie
    {
        Task<List<EspecieDto>> GetAllEspeciesAsync();
    }
}
