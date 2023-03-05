using Modsen.Business.Models;

namespace Modsen.Business.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponse> LoginAsync(LoginModel user);

        public Task<RegisterResponse> RegisterAsync(RegisterModel model);
    }
}