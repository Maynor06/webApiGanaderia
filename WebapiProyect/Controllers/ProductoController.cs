using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var results = await _producto.GetProductos();
            return Ok(results);
        }


    }
}
