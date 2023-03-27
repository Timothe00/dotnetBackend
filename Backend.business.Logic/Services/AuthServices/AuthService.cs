using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Backend.business.Logic.Services.AuthServices
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        private readonly presenceManagementDbContext _DbContext;
        public AuthService(presenceManagementDbContext DbContext, IConfiguration configuration)
        {
            _DbContext = DbContext;
            _configuration = configuration;
        }

        public Users Authenticate(Login Logins)
        {
            var user = _DbContext.Users.Where(u => u.UsersEmail == Logins.UsersEmail).FirstOrDefault();
            if (user != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(Logins.UsersPassword, user.UsersPassword);
                if (isPasswordValid)
                {
                    return user;
                }
            }
            return null;
        }
        public string Token(Users user)
        {
            string? role = _DbContext.Roles.Where(r => r.RoleId == user.RoleId).Select(role => role.RoleName).FirstOrDefault();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Role ,role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}


