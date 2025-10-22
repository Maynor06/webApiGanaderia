using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface ICargo
    {

        Task<Cargo> CreateCargo(Cargo cargo);
        Task<List<Cargo>> GetAllCargos();
    }
}
