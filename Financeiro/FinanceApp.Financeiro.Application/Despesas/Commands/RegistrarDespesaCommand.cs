using FinanceApp.Shared;
using MediatR;

namespace FinanceApp.Financeiro.Application.Despesas.Commands;

public record RegistrarDespesaCommand(
    Guid UsuarioId,
    string Categoria,
    decimal Valor,
    DateTime Data,
    string Descricao
) : IRequest<Result<Guid>>;
