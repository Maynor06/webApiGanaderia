using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamento _medicamento;

        public MedicamentoController(IMedicamento medicamento)
        {
            _medicamento = medicamento;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicamentosConCantidadYFechaVencimiento()
        {
            var results = await _medicamento.getMedicamentosConCantidadYFechaVencimiento();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicamento([FromBody] Models.Medicamento medicamento)
        {
            var createdMedicamento = await _medicamento.CreateMedicamentoAsync(medicamento);
            return Ok(createdMedicamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMedicamento(long id, [FromBody] Models.Medicamento medicamento)
        {
            var updatedMedicamento = await _medicamento.ActualizarMedicamento(id, medicamento);
            return Ok(updatedMedicamento);
        }

    }
}
