using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraestructuraController : ControllerBase
    {
        private readonly IInfraestructura _infraestructura;
        public InfraestructuraController(IInfraestructura infraestructura)
        {
            _infraestructura = infraestructura;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistros()
        {
            var results = await _infraestructura.getRegistros();
            return Ok(results);
        }

    }
}
