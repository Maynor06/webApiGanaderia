using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class AnimalService : IAnimalService
    {

        private readonly ApplicationDbContext _context;

        public AnimalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> CreateAnimal(Animal animal)
        {
            try
                {
                _context.Animals.Add(animal);
                await _context.SaveChangesAsync();
                return animal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el animal", ex);
            }
        }

        public async Task<bool> DeleteAnimal(long id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
                return false;

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Animal?> GetAnimalById(long id)
        {
            return await _context.Animals.FindAsync(id);
        }


        public async Task<Animal?> UpdateAnimal(long id, Animal animal)
        {
            try
            {
                Animal animalFound = await _context.Animals.FindAsync(id);
                if (animalFound == null)
                {  
                    return null;
                }
                animalFound.Nombre = animal.Nombre;
                animalFound.Peso = animal.Peso;
                animalFound.Especie = animal.Especie;
                animalFound.Raza = animal.Raza;
                animalFound.Estado = animal.Estado;
                animalFound.FotoUrl = animal.FotoUrl;
                await _context.SaveChangesAsync();
                return animalFound;
            } catch (Exception ex)
            {
                throw new Exception("Error al actualizar el animal", ex);
            }

        }
    }
}
