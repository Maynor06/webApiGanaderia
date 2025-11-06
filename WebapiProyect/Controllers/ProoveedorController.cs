using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/Proveedor")]
    [ApiController]
    public class ProoveedorController : ControllerBase
    {

        private readonly IProveedor _proveedor;

        public ProoveedorController(IProveedor proveedor)
        {
            _proveedor = proveedor;
        }


        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {
            var results = await _proveedor.GetProveedores();
            return Ok(results);
        }
    }
}
