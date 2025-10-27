using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface Ipotrero
    {
        Task<List<Potrero>> GetAllPotrerosAsync();
        Task<Potrero> CreatePotreroAsync(Potrero potrero);
        Task<Potrero> UpdatePotreroAsync(long id, Potrero potrero);
        Task<bool> DeletePotreroAsync(long id);

    }
}
