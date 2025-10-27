using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazaController : ControllerBase
    {
        private readonly IRaza raza;

        public RazaController(IRaza raza)
        {
            this.raza = raza;
        }

        [HttpGet]
        [Route("RazaPorEspecie/{idEspecie}")]
        public async Task<IActionResult> GetRazaPorEspecie(long idEspecie)
        {
            var razas = await raza.GetRazasByEspecieIdAsync(idEspecie);
            return Ok(razas);
        }
    }
}
