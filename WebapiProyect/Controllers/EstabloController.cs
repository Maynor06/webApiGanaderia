using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabloController : ControllerBase
    {
        private readonly IEstablo _establo; 

        public EstabloController(IEstablo establo)
        {
            _establo = establo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstablos()
        {
            var results = await _establo.GetAllEstablosAsync();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstablo([FromBody] Models.Establo establo)
        {
            if (establo == null) return BadRequest(new { message = "No hay datos" });
            var created = await _establo.CreateEstabloAsync(establo);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablo(long id, [FromBody] Models.Establo establo)
        {
            var updateEstablo = await _establo.UpdateEstabloAsync(id, establo);
            if(updateEstablo == null) return NotFound( new {message = "El establo no existe"} );
            return Ok(new
            {
                message = "Establo actualizado con exito", 
                data = updateEstablo
            });
        }

    }
}
