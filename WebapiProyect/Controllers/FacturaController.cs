using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturas _factura;

        public FacturaController(IFacturas factura)
        {
            _factura = factura;
        }

        [HttpGet]
        public   Task<IActionResult> GetFacturasConDetalles()
        {
            var results = _factura.GetFacturas();
            return results.ContinueWith(task => (IActionResult)Ok(task.Result));

        }
        [HttpPost]
        public async Task<IActionResult> CreateFactura([FromBody] Models.Factura factura)
        {
            var createdFactura = await _factura.CreateFactura(factura);
            return Ok(createdFactura);
        }
        [HttpPut("{id}") ]
        public async Task<IActionResult> ActualizarFactura(long id, [FromBody] Models.Factura factura)
        {
            var updatedFactura = await _factura.ActualizarFactura(id, factura);
            return Ok(updatedFactura);
        }

    }
}
