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
        public async Task<IActionResult> createAnimal([FromBody] Animal animal)
        {

            if (animal == null) return BadRequest(new { message = "no hay datos" });
                
            var created = await _animalService.CreateAnimal(animal);

            return CreatedAtAction(nameof(GetAnimalById), new {id = created.IdAnimal}, new
            {
                message = "Animal creado correctamente.",
                data = created
            });

        }

    }
}
