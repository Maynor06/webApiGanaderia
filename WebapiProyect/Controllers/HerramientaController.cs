using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerramientaController : ControllerBase
    {
        private readonly IHerramienta _herramienta;

        public HerramientaController(IHerramienta herramienta)
        {
            _herramienta = herramienta;
        }

        [HttpGet]
        public async Task<IActionResult> GetHerramientasConCantidadDisponible()
        {
            var results = await _herramienta.GetHerramientasConCantidadDisponible();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHerramienta([FromBody] Models.Herramientum herramienta)
        {
            var createdHerramienta = await _herramienta.CreateHerramienta(herramienta);
            return Ok(createdHerramienta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarHerramienta(long id, [FromBody] Models.Herramientum herramienta)
        {
            var updatedHerramienta = await _herramienta.ActualizarHerramienta(id, herramienta);
            return Ok(updatedHerramienta);
        }

    }
}
