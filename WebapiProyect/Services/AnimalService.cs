using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
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

        public async Task<AnimalDto?> GetAnimalById(long id)
        {

            Animal animal =  await _context.Animals.FindAsync(id);
            Raza raza = await _context.Razas.FindAsync(animal.RazaId);
            Especie especie = await _context.Especies.FindAsync(animal.EspecieId);

            if (animal == null)
            {
                return null;
            }
            AnimalDto animalDto = new AnimalDto
            {
                Id = animal.IdAnimal,
                Nombre = animal.Nombre,
                Peso = animal.Peso?.ToString(),
                Especie = especie != null ? especie.Nombre : null,
                Raza = raza != null ? raza.Nombre : null,
                Estado = animal.Estado,
                Sexo = animal.Sexo,
                Edad = animal.FechaNacimiento != null ? (DateTime.Now.Year - animal.FechaNacimiento.Value.Year).ToString() : null,
                Codigo = animal.Codigo
            };

            return animalDto;

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
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el animal", ex);
            }

        }

        public async Task<List<AnimalDto>> GetAllAnimalsAsync()
        {
            List<AnimalDto > listAnimals = await _context.animalDto
                .FromSqlInterpolated($"EXEC PA_tabla1_animales")
                .ToListAsync();

            return listAnimals;
        }

        public async Task<List<Animal>> GetAnimalsForEstado(string estado)
        {
            List<Animal> listAnimals = await _context.Animals
                .Where(a => a.Estado == estado)
                .ToListAsync();
            return listAnimals;
        }
        public async Task<GestionAnimalDto> GetGestionAnimal()
        {
            int totalAnimales = await _context.Animals.CountAsync();
            int animalesActivos = await _context.Animals.CountAsync(animal => animal.Estado == "Activo");
            int animalesEnTratamiento = await _context.AplicacionTratamientos.CountAsync();
            int pesoPromedio = (int)await _context.Animals.AverageAsync(animal => animal.Peso ?? 0);
            GestionAnimalDto gestionAnimals = new GestionAnimalDto
            {
                TotalAnimales = totalAnimales,
                TotalAnimalesActivos = animalesActivos,
                TotalAnimalesEnTratamiento = animalesEnTratamiento,
                PesoPromedio = pesoPromedio
            };

            return gestionAnimals;
        }
    }
}
