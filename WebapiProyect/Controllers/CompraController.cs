using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompra _compra; 

        public CompraController(ICompra compra)
        {
            _compra = compra;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllsCompras()
        {
            var results = await _compra.GetComprasAsync();
            return Ok(results);
        }
    }
}
