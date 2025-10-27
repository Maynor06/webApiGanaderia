using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null) return BadRequest(new { message = "No hay datos" });
            var created = await _empleadoService.CreateEmpleado(empleado);
            return CreatedAtAction(nameof(GetEmpleadoById), new { id = created.IdEmpleado }, new
            {
                message = "Empleado creado correctamente.",
                data = created
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleados();
            return Ok(empleados);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmpleadoById(long id)
        {
            var empleado = await _empleadoService.GetEmpleadoById(id);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEmpleado(long id)
        {
            var result = await _empleadoService.DeleteEmpleado(id);
            if (!result)
                return NotFound(new { message = "Empleado no encontrado." });
            return Ok(new { message = "Empleado eliminado correctamente." });
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateEmpleado(long id, [FromBody] Empleado empleado)
        {
            var updatedEmpleado = await _empleadoService.UpdateEmpleado(id, empleado);
            if (updatedEmpleado == null)
                return NotFound(new { message = "Empleado no encontrado." });
            return Ok(new
            {
                message = "Empleado actualizado correctamente.",
                data = updatedEmpleado
            });
        }

        [HttpGet]
        [Route("cargo/{cargoId}")]
        public async Task<IActionResult> GetEmpleadosByCargoId(long cargoId)
        {
            var empleados = await _empleadoService.GetEmpleadosByCargoId(cargoId);
            return Ok(empleados);
        }

    }
}
