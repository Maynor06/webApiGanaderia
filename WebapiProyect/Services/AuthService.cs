using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<Usuario> _passwordHasher = new();

        public AuthService(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<Usuario> RegisterAsync(UserRegisterDto userRegister)
        {
            var userExists = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == userRegister.Username);
            
            if (userExists != null)
            {
                throw new Exception("El usuario ya existe");
            }
            var user = new Usuario
            {
                Nombre = userRegister.Username,
                Rol = userRegister.Role
            };

            user.ContrasenaHash = _passwordHasher.HashPassword(user, userRegister.Password);
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string?> LoginAsync(UserLoginDto userLogin)
        {
            
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == userLogin.Username);

            if (usuario == null) return null;
            if( string.IsNullOrEmpty(usuario.ContrasenaHash)) return null;

            var validation = _passwordHasher.VerifyHashedPassword(usuario, usuario.ContrasenaHash, userLogin.Password);
            if (validation == PasswordVerificationResult.Failed) return null;

            return GenerarToken(usuario);

        }

        private string GenerarToken(Usuario usuario)
        {
            var jwtSection = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new("Id", usuario.IdUsuario.ToString()),
                new("Nombre", usuario.Nombre ?? "" ),
                new("Rol", usuario.Rol ?? "Default")
            };

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSection["ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
