using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/open")]
    [ApiController]
    public class TestIAController : ControllerBase
    {
        private readonly IOpenAIService _openAIService; 

        public TestIAController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpGet("test-openai")]
        public async Task<IActionResult> TestOpenAIConnection()
        {
            // Llamas a la función de prueba
            var result = await _openAIService.probarConexion();

            if (result.StartsWith("Error"))
            {
                return StatusCode(500, result);
            }

            return Ok(result);
        }

        [HttpPost("report")]
        public async Task<IActionResult> GenerateReport([FromBody] CharRequest request)
        {
            var prompt = request.UserPrompt;
            if (string.IsNullOrEmpty(prompt))
            {
                return BadRequest("La pregunta del usuario no puede estar vacía.");
            }
            var report = await _openAIService.procesarDataAsync(prompt);
            if (report.StartsWith("Error"))
            {
                return StatusCode(500, report);
            }
            return Ok(report);
        }

    }
}
