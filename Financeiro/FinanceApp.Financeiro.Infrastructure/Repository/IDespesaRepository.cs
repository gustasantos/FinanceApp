using FinanceApp.Financeiro.Domain;

namespace FinanceApp.Financeiro.Infrastructure;

public interface IDespesaRepository
{
    Task AdicionarDespesaAsync(Despesa despesa);
    Task<List<Despesa>> ObterDespesasPorUsuarioMesAsync(Guid usuarioId, int ano, int mes);
}
