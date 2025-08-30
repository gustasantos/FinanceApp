
namespace FinanceApp.Financeiro.Application.Despesas.Contracts;

public record DespesaResponse(Guid Id, string Categoria, decimal Valor, DateTime Data);

