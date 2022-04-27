using DesafioDesafiante.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioDesafiante.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role"); // Nome da Tabela
            builder.HasKey(x => x.Id); // Identificando a PK
            builder.Property(x => x.Id) // (IDENTITY 1,1)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired() // NOT NULL
                .HasColumnName("RoleName") // Nome da Coluna
              //  .HasColumnType("NVARCHAR")
                .HasMaxLength(80); // Tamanho

            builder.Property(x => x.Users);
        }
    }
}
