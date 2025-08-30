using FinanceApp.Financeiro.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Financeiro.Infrastructure;

public class DespesaRepository(FinanceiroDbContext context) : IDespesaRepository
{
    public async Task AdicionarDespesaAsync(Despesa despesa)
    {
        await context.Despesas.AddAsync(despesa);
        await context.SaveChangesAsync();
    }

    public async Task<List<Despesa>> ObterDespesasPorUsuarioMesAsync(Guid usuarioId, int ano, int mes)
    {
        var query = context.Despesas.Where(d => d.UsuarioId == usuarioId);

        if (ano > 0) query = query.Where(d => d.Data.Year == ano);
        if (mes > 0) query = query.Where(d => d.Data.Month == mes);

        var despesas = await query.ToListAsync();
        return despesas;
    }
}
