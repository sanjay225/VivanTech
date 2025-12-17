using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VivanInfotech.API.Models;
using VivanInfotech.API.Repositories;

namespace VivanInfotech.API.Services
{
    public class AuthService
    {
        private readonly IRepository _repo;
        private readonly IConfiguration _config;

        public AuthService (IRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task RegisterAsync(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _repo.AddAsync(user);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = (await _repo.FindAsync<User>(x => x.Email == email)).FirstOrDefault();
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);

            var token = new JwtSecurityTokenHandler().CreateToken(
                new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256
                    )
                });

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
