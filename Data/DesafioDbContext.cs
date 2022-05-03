using DesafioDesafiante.Models;
using DesafioDesafiante.Seeds;
using DesafioDesafiante.Services;
using Microsoft.EntityFrameworkCore;

namespace DesafioDesafiante.Data
{
    public class DesafioDbContext : DbContext
    {
        private readonly PasswordService _passwordService = new PasswordService();
        private const string ConnectionString = "Server=.\\SQLExpress;Database=Desafio;TrustServerCertificate=True;Integrated Security=True;";


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Implementar Reflection 
            //new RoleSeed().SeedData(modelBuilder);
            //new UserSeed().SeedData(modelBuilder, _passwordService);


            var type = typeof(ISeeder);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(x => x.GetTypes())
                        .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(x => Activator.CreateInstance(x))
                        .Cast<ISeeder>();

            foreach (var seeder in types)
                seeder.SeedData(modelBuilder, _passwordService);
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);
    }
}
