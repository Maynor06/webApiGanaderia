using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.DTO;
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

        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] compraRequestDto compraDto)
        {
            var result = await _compra.CreateCompra(compraDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateCompra([FromBody] compraRequestDto compraDto, long id)
        {
            var result = await _compra.UpdateCmpra(compraDto, id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCompra(long id)
        {
            var result = await _compra.DeleteCompra(id);
            if (!result)
                return NotFound(new { message = "Compra no encontrada." });
            return Ok(new { message = "Compra eliminada correctamente." });
        }

    }
}
