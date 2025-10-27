using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspecie _especieService;
        public EspecieController(IEspecie especieService)
        {
            _especieService = especieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEspecies()
        {
            var especies = await _especieService.GetAllEspeciesAsync();
            return Ok(especies);
        }
    }
}
