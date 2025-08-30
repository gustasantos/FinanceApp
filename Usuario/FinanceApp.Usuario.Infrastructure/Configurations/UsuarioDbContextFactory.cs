using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanceApp.Usuarios.Infrastructure.Configurations;

public class UsuarioDbContextFactory : IDesignTimeDbContextFactory<UsuarioDbContext>
{
    public UsuarioDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UsuarioDbContext>();
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-2I60P6UI\\SQLEXPRESS;Initial Catalog=FinanceAppDb;Integrated Security=True;TrustServerCertificate=True;");
        return new UsuarioDbContext(optionsBuilder.Options);
    }
}
