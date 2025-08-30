using FinanceApp.Shared;
using FinanceApp.Usuario.Application.Usuarios.Queries;
using FinanceApp.Usuarios.Application.Usuarios.Contracts;
using FinanceApp.Usuarios.Infrastructure.Repository;
using MediatR;

namespace FinanceApp.Usuario.Application.Usuarios.Handler;

public class ObterUsuarioQueryHandler(IUsuarioRepository repository)
    : IRequestHandler<ObterUsuarioQuery, Result<UsuarioResponse>>
{
    public async Task<Result<UsuarioResponse>> Handle(ObterUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = await repository.ObterPorIdAsync(request.UsuarioId);

        if (usuario is null)
            return Result<UsuarioResponse>.Fail("Usuário não encontrado");
            
        return Result<UsuarioResponse>.Success(
            new UsuarioResponse(usuario.Id, usuario.Nome, usuario.Email));
    }
}

