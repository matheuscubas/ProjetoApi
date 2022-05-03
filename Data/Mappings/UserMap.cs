using DesafioDesafiante.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioDesafiante.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User"); // Nome da Tabela
            builder.HasKey(x => x.Id); // Identificando a PK
            builder.Property(x => x.Id) // (IDENTITY 1,1)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Username)
                .IsRequired() // NOT NULL
                .HasColumnName("Username") // Nome da Coluna
                .HasColumnType("NVARCHAR") // Tipo de caracter
                .HasMaxLength(80); // Tamanho

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(25);


            //Relacionamentos
            builder.HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .HasConstraintName("FK_User_Role")
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
