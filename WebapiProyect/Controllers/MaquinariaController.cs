using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinariaController : ControllerBase
    {
        private readonly IMaquinaria _maquinaria;

        public MaquinariaController(IMaquinaria maquinaria)
        {
            _maquinaria = maquinaria;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaquinarias()
        {
            var results = await _maquinaria.GetMaquinarias();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaria([FromBody] Maquinarium maquinaria)
        {
            var result = await _maquinaria.CreateMaquinaria(maquinaria);
            return Ok(result);

        }

        [HttpPut("{id}") ]
        public async Task<IActionResult> UpdateMaquinaria(long id, [FromBody] Maquinarium maquinaria)
        {
            var result = await _maquinaria.ActualizarMaquinaria(id, maquinaria);
            return Ok(result);

        }


    }
}
