using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorralController : ControllerBase
    {
        private readonly ICorral _icorral;

        public CorralController(ICorral icorral)
        {
            _icorral = icorral;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCorrales()
        {
            var results = await _icorral.GetAllCorralesAsync();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCorral([FromBody] Models.Corral corral)
        {
            if (corral == null) return BadRequest(new { message = "No hay datos" });
            var created = await _icorral.CreateCorralAsync(corral);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCorral(long id, [FromBody] Models.Corral corral)
        {
            var updateCorral = await _icorral.UpdateCorralAsync(id, corral);
            if (updateCorral == null) return NotFound(new { message = "El corral no existe" });
            return Ok(new
            {
                message = "Corral actualizado con exito",
                data = updateCorral
            });
        }

    }
}
