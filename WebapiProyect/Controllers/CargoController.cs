using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargo _cargoService;

        public CargoController(ICargo cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargos()
        {
            var cargos = await _cargoService.GetAllCargos();
            return Ok(cargos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargo([FromBody] Cargo cargo)
        {
            if (cargo == null) return BadRequest(new { message = "No hay datos" });
            var created = await _cargoService.CreateCargo(cargo);
            return CreatedAtAction(nameof(created), new { id = created.IdCargo }, new
            {
                message = "Cargo creado correctamente.",
                data = created
            });
        }

    }
}
