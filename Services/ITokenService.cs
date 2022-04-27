using DesafioDesafiante.Models;
using DesafioDesafiante.ViewModels;

namespace DesafioDesafiante.Services
{
    public interface ITokenService
    {
        public string GenerateToken(LoginUserViewModel user);
    }
}
