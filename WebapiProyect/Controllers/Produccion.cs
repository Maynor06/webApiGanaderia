using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/Produccion")]
    [ApiController]
    public class Produccion : ControllerBase
    {
        private readonly IProduccion _produccion; 

        public Produccion(IProduccion produccion)
        {
            _produccion = produccion;
        }

        [HttpGet]
        public async Task<ActionResult> GetProduccionMesLater()
        {
            var results = await _produccion.GetProduccionMesLater();
            return Ok(results);
        }
    }
}
