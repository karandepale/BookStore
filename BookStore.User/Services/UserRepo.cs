using BookStore.User.Context;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.User.Services
{
    public class UserRepo
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;
        public UserRepo(UserContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }


        // JWT TOKEN GENERATE:-
        public string GenerateJwtToken(string Email, long UserID)
        {
            var claims = new List<Claim>
            {
                new Claim("UserID", UserID.ToString()),
                new Claim(ClaimTypes.Email, Email),
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["JwtSettings:Issuer"], configuration["JwtSettings:Audience"], claims, DateTime.Now, DateTime.Now.AddHours(1), creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
