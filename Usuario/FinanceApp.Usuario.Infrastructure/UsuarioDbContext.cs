using System;
using FinanceApp.Usuarios.Domain;
using FinanceApp.Usuarios.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Usuarios.Infrastructure;

public class UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
