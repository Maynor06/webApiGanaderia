using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> RegisterAsync(UserRegisterDto userRegister);

        Task <string?> LoginAsync(UserLoginDto userLogin);

    }
}
