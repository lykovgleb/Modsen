using Modsen.BL.Models;

namespace Modsen.BL.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponse> LoginAsync(LoginModel user);

        public Task<RegisterResponse> RegisterAsync(RegisterModel model);
    }
}