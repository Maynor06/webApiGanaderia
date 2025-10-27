using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IRaza
    {
        Task<List<Raza>> GetRazasByEspecieIdAsync(long especieId);
    }
}
