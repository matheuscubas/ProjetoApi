using DesafioDesafiante.Models;
using DesafioDesafiante.ViewModels;

namespace DesafioDesafiante.Services
{
    using BCrypt = BCrypt.Net.BCrypt;

    public class PasswordService : IPasswordService
    {
        public string GeneratePassword()
        {
            var guid = Guid.NewGuid();
            string preEncryptPassword = guid.ToString()[..25];
            return preEncryptPassword;
        }

        public string EncryptPassword(string password)
            => BCrypt.HashPassword(password);

        public bool IsCorrectPassword(string password, LoginUserViewModel user)
           => BCrypt.Verify(password, user.Password);
    }
}
