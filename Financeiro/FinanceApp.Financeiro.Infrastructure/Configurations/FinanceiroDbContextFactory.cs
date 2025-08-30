using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanceApp.Financeiro.Infrastructure.Configurations;

public class FinanceiroDbContextFactory : IDesignTimeDbContextFactory<FinanceiroDbContext>
{
    public FinanceiroDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FinanceiroDbContext>();
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-2I60P6UI\\SQLEXPRESS;Initial Catalog=FinanceAppDb;Integrated Security=True;TrustServerCertificate=True;");
        return new FinanceiroDbContext(optionsBuilder.Options);
    }
}
