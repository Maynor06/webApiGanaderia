using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface ICorral
    {
        Task<List<Corral>> GetAllCorralesAsync();
        Task<Corral> CreateCorralAsync(Corral corral);
        Task<Corral> UpdateCorralAsync(long id, Corral corral);

    }
}
