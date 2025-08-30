
namespace FinanceApp.Financeiro.Application.Despesas.Contracts;

public record DespesaRequest
{
    public Guid UsuarioId { get; init; }
    public string Categoria { get; init; } = string.Empty;
    public decimal Valor { get; init; }
    public DateTime Data { get; init; }
    public string? Descricao { get; init; }
}
