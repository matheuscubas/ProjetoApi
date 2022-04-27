using DesafioDesafiante.Models;
using DesafioDesafiante.Services;
using Microsoft.EntityFrameworkCore;


namespace DesafioDesafiante.Seeds
{
    public class UserSeed : ISeeder
    {
        public void SeedData(ModelBuilder builder, PasswordService _passwordService)
        {
            builder.Entity<User>().HasData(
                new User
                {

                    Id = 1,
                    Username = "Matheus",
                    Password = _passwordService.EncryptPassword("teste123"),
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    Username = "PrimeiroCliente",
                    Password = _passwordService.EncryptPassword("secreto123"),
                    RoleId = 2
                }
                );
        }
    }
}
