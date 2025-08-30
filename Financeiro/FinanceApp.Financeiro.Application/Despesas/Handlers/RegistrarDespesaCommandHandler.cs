using FinanceApp.Financeiro.Application.Despesas.Commands;
using FinanceApp.Financeiro.Domain;
using FinanceApp.Financeiro.Infrastructure;
using FinanceApp.Shared;
using MediatR;

namespace FinanceApp.Financeiro.Application.Despesas.Handlers;

public class RegistrarDespesaCommandHandler(IDespesaRepository repository)
    : IRequestHandler<RegistrarDespesaCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegistrarDespesaCommand request, CancellationToken cancellationToken)
    {
        var resultado = Despesa.Criar(request.UsuarioId, request.Categoria, request.Valor, request.Data, request.Descricao);

        if (!resultado.IsSuccess)
            return Result<Guid>.Fail(resultado.Error!);
            
        var despesa = resultado.Value!;
        await repository.AdicionarDespesaAsync(despesa);

        return Result<Guid>.Success(despesa.Id);
    }
}