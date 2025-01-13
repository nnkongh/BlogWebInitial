using BlogWeb.Models;
using BlogWeb.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogWeb.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Role,"User")
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var descriptToken = new SecurityTokenDescriptor
            {
                SigningCredentials = creds,
                Issuer = _config["JwtSettings:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(5),
                Audience = _config["JwtSettings:Audience"],
                Subject = new ClaimsIdentity(claims),
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptToken);
            return handler.WriteToken(token);
        }
    }
}
