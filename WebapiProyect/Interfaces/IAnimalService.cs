using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IAnimalService {

        Task<Animal?> GetAnimalById(long id);
        Task<Animal> CreateAnimal(Animal animal);
        Task<Animal?> UpdateAnimal(long id, Animal animal);
        Task<bool> DeleteAnimal(long id);
    }
}
