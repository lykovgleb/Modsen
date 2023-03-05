using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modsen.BL.Interfaces;
using Modsen.BL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modsen.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResponse> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return GetToken(user);
            }
            else
            {
                throw new Exception("Wrong name or password");
            }
        }


        public async Task<RegisterResponse> RegisterAsync(RegisterModel model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.UserName);

            if (existingUser != null)
            {
                return new RegisterResponse
                {
                    Status = "Error",
                    Info = new List<string> { "User already exist!" }
                };
            }

            var user = new IdentityUser
            {
                UserName = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
        
                return new RegisterResponse
                {
                    Status = "Error",
                    Info = result.Errors.Select(x => x.Description).ToList(),
                };
            }

            return new RegisterResponse
            {
                Status = "Success",
                Info = new List<string> { "User created successfully!" }
            };
        }

        private LoginResponse GetToken(IdentityUser user)
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }
    }
}
