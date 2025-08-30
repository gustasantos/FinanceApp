using System;
using FinanceApp.Usuarios.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.Usuarios.Infrastructure.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
               .ValueGeneratedNever(); 

        builder.Property(u => u.Nome)
               .IsRequired();

        builder.Property(u => u.Email)
               .IsRequired();

        builder.Property(u => u.Nome)
               .HasMaxLength(100);

        builder.Property(u => u.Email)
               .HasMaxLength(200);
    }
}
