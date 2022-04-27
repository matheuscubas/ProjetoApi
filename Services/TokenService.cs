using DesafioDesafiante.Models;
using DesafioDesafiante.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioDesafiante.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(LoginUserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {   
                Subject = new ClaimsIdentity(new Claim[]{
                    new (ClaimTypes.Name, user.Username),
                    new (ClaimTypes.Role, user.Rolename),
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
