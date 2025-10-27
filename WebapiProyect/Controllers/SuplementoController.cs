using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplementoController : ControllerBase
    {
        private readonly Isuplementos _isuplementos;

        public SuplementoController(Isuplementos isuplementos)
        {
            _isuplementos = isuplementos;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSuplementos()
        {
            var results = await _isuplementos.GetSuplementosAsync();
            return Ok(results);
        }

    }
}
