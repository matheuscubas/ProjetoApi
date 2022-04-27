using DesafioDesafiante.Models;
using DesafioDesafiante.ViewModels;

namespace DesafioDesafiante.Services
{
    public interface IPasswordService
    {
        public string GeneratePassword();

        public string EncryptPassword(string password);

        public bool IsCorrectPassword(string password, LoginUserViewModel user);
    }
}
