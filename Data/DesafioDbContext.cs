using DesafioDesafiante.Models;
using DesafioDesafiante.Seeds;
using DesafioDesafiante.Services;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesafiante.Data
{
    public class DesafioDbContext : DbContext
    {
        private readonly PasswordService passwordService = new();
        private const string ConnectionString = "Server=.\\SQLExpress;Database=Desafio;TrustServerCertificate=True;Integrated Security=True;";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Implementar Reflection 
            new RoleSeed().SeedData(modelBuilder);
            new UserSeed().SeedData(modelBuilder, passwordService);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);
    }
}
