using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotreroController : ControllerBase
    {

        private readonly Ipotrero _ipotrero; 

        public PotreroController(Ipotrero ipotrero)
        {
            _ipotrero = ipotrero;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPotreros()
        {
            var results = await _ipotrero.GetAllPotrerosAsync();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePotrero([FromBody] Potrero potrero)
        {
            if (potrero == null) return BadRequest(new { message = "No hay datos" });

            var created = await _ipotrero.CreatePotreroAsync(potrero);

            return Ok(created);
        }
        
        [HttpPut("{id}") ]
        public async Task<IActionResult> UpdatePotrero(long id, [FromBody] Potrero potrero)
        {
            var updatePotrero = await _ipotrero.UpdatePotreroAsync(id, potrero);
            if(updatePotrero == null) return NotFound( new {message = "El potrero no existe"} );
            return Ok(new
            {
                message = "Potrero actualizado con exito", 
                data = updatePotrero
            });
        }

    }
}
