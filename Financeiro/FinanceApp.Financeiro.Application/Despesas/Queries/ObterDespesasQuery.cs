using FinanceApp.Financeiro.Application.Despesas.Contracts;
using FinanceApp.Shared;
using MediatR;

namespace FinanceApp.Financeiro.Application.Despesas.Queries;

public record ObterDespesasQuery(Guid UsuarioId, int Mes, int Ano) : IRequest<Result<List<DespesaResponse>>>;
