using DesafioDesafiante.Models;
using DesafioDesafiante.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesafiante.Seeds
{
    public class RoleSeed : ISeeder
    {
        public void SeedData(ModelBuilder builder, PasswordService? passwordService = null)
        {
            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Client"
                }
                );
        }
    }
}
