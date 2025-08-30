using FinanceApp.Financeiro.Application.Despesas.Contracts;
using FinanceApp.Financeiro.Application.Despesas.Queries;
using FinanceApp.Financeiro.Infrastructure;
using FinanceApp.Shared;
using MediatR;

namespace FinanceApp.Financeiro.Application.Despesas.Handlers;

public class ObterDespesasQueryHandler(IDespesaRepository repository)
    : IRequestHandler<ObterDespesasQuery, Result<List<DespesaResponse>>>
{
    public async Task<Result<List<DespesaResponse>>> Handle(ObterDespesasQuery request, CancellationToken cancellationToken)
    {
        if (request.Mes is > 0 and > 12) 
            return Result<List<DespesaResponse>>.Fail("Mês inválido.");

        if (request.Ano > 0)
        {
            if (request.Ano < 2000 || request.Ano > DateTime.Now.Year)
                return Result<List<DespesaResponse>>.Fail("Ano inválido.");
        }
        
        var despesas = await repository.ObterDespesasPorUsuarioMesAsync(request.UsuarioId, request.Mes, request.Ano);

        var dtos = despesas.Select(d =>
            new DespesaResponse(d.Id, d.Categoria, d.Valor, d.Data)).ToList();

        return Result<List<DespesaResponse>>.Success(dtos);
    }
}
