using FinanceApp.Financeiro.Domain;
using FinanceApp.Financeiro.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Financeiro.Infrastructure;

public class FinanceiroDbContext(DbContextOptions<FinanceiroDbContext> options) : DbContext(options)
{
    public DbSet<Despesa> Despesas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DespesaConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
