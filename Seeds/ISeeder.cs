using DesafioDesafiante.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesafiante.Seeds
{
    public interface ISeeder
    {
        // um metodo void ModelBuilder
        public void SeedData(ModelBuilder builder, [FromServices] PasswordService? _passwordService = null);
    }
}
