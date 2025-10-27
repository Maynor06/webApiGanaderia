using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IAnimalService {

        Task<AnimalDto> GetAnimalById(long id);
        Task<Animal> CreateAnimal(Animal animal);
        Task<Animal?> UpdateAnimal(long id, Animal animal);
        Task<bool> DeleteAnimal(long id);
        Task<List<AnimalDto>> GetAllAnimalsAsync();
        Task<List<Animal>> GetAnimalsForEstado(string estado);
        Task<GestionAnimalDto> GetGestionAnimal();

    }
}
