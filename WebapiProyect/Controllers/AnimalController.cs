using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;
using WebapiProyect.Services;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(long id)
        {
            var animal = await _animalService.GetAnimalById(id);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] Animal animal)
        {

            if (animal == null) return BadRequest(new { message = "no hay datos" });
                
            var created = await _animalService.CreateAnimal(animal);

            return CreatedAtAction(nameof(GetAnimalById), new {id = created.IdAnimal}, new
            {
                message = "Animal creado correctamente.",
                data = created
            });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(long id, [FromBody] Animal animal)
        {
            var updatedAnimal = await _animalService.UpdateAnimal(id, animal);
            if (updatedAnimal == null)
                return NotFound(new { message = "Animal no encontrado." });
            return Ok(new
            {
                message = "Animal actualizado correctamente.",
                data = updatedAnimal
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(long id)
        {
            var result = await _animalService.DeleteAnimal(id);
            if (!result)
                return NotFound(new { message = "Animal no encontrado." });
            return Ok(new { message = "Animal eliminado correctamente." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _animalService.GetAllAnimalsAsync();
            return Ok(animals);
        }

        [HttpGet]
        [Route("estado/{estado}")]
        public async Task<IActionResult> GetAnimalsForEstado(string estado)
        {
            var animals = await _animalService.GetAnimalsForEstado(estado);
            return Ok(animals);
        }

        [HttpGet]
        [Route("gestion")]
        public async Task<IActionResult> GetGestionAnimal()
        {
            var gestionAnimal = await _animalService.GetGestionAnimal();
            return Ok(gestionAnimal);
        }

    }
}
