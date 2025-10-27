using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitacionController : ControllerBase
    {
        private readonly ICapacitacion _capacitacion;

        public CapacitacionController(ICapacitacion capacitacion)
        {
            _capacitacion = capacitacion;
        }

        [HttpGet]
        public IActionResult GetAllCapacitacions()
        {
            var capacitaciones = _capacitacion.GetAllCapacitaciones();
            return Ok(capacitaciones);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCapacitacion([FromBody] Capacitacion capacitacion)
        {
            if (capacitacion == null) return BadRequest(new { message = "no hay datos" });

            var created = await _capacitacion.CreateCapacitacion(capacitacion);

            return Ok(created);
        }

        [HttpPut("{id}") ]
        public async Task<IActionResult> UpdateCapacita(long id, [FromBody] Capacitacion capacitacion)
        {
            var updateCapacitacion = await _capacitacion.UpdateCapacitacion(id, capacitacion);

            return Ok(updateCapacitacion);
        }

    }
}
