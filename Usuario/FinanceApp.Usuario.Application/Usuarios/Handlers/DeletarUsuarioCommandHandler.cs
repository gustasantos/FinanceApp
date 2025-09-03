using FinanceApp.Shared;
using FinanceApp.Usuarios.Application.Usuarios.Commands;
using FinanceApp.Usuarios.Infrastructure.Repository;
using MediatR;

namespace FinanceApp.Usuarios.Application.Usuarios.Handlers;

public class DeletarUsuarioCommandHandler(IUsuarioRepository repository) : IRequestHandler<DeletarUsuarioCommand, Result>
{
    public async Task<Result> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await repository.ObterPorIdAsync(request.UsuarioId);
        
        if(usuario is null)
            return Result.Fail("Usuário não encontrado");
        
        var resultado = usuario.Deletar();
        if (!resultado.IsSuccess)
            return resultado;
        
        await repository.RemoverAsync(usuario);
        return Result.Success("Usuário deletado com sucesso!");

    }
}