using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegister)
        {
            try
            {
                var user = await _authService.RegisterAsync(userRegister);
                return Created("", new
                {
                    message = "Usuario creado correctamente.",
                    data = user
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var token = await _authService.LoginAsync(userLogin);
            if (token == null)
                return Unauthorized(new { message = "Credenciales inválidas." });
            return Ok(new
            {
                message = "Inicio de sesión exitoso.",
                token = token
            });
        }

    }
}
