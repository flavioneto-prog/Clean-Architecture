using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIOS");

            builder.Property(e => e.UsuarioId)
                .ValueGeneratedOnAdd()
                .HasColumnName("USUARIO_ID");

            builder.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("DATA_NASCIMENTO")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOME")
                .IsRequired();

            builder.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SENHA")
                .IsRequired();

            builder.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SEXO")
                .IsFixedLength(true)
                .IsRequired();

            builder.HasIndex(i => i.Nome).HasName("idx_usuario_nome");
        }
    }
}
