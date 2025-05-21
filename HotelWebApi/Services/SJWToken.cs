using Azure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelWebApi.Services
{
    public class SJWToken
    {
        private readonly IConfiguration _config;
        public SJWToken(IConfiguration config)
        {
            _config = config;
        }
        public string generateToken(string email,string id, string role)
        {
            //realizacion de token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
       {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Role, role)
            }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(
           new SymmetricSecurityKey(key),
           SecurityAlgorithms.HmacSha256Signature
       ),
                Issuer = "HotelWebApi",
                Audience = "HotelWebApi"
            }
        ;

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
