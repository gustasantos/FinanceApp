using FinanceApp.Shared;
using FinanceApp.Usuarios.Application.Usuarios.Commands;
using FinanceApp.Usuarios.Infrastructure.Repository;
using MediatR; 

namespace FinanceApp.Usuarios.Application.Usuarios.Handlers;

public class RegistrarUsuarioCommandHandler(IUsuarioRepository repository)
    : IRequestHandler<RegistrarUsuarioCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegistrarUsuarioCommand command, CancellationToken cancellationToken)
    {
        var resultado = Domain.Usuario.Criar(command.Nome, command.Email);

        if (!resultado.IsSuccess)
            return Result<Guid>.Fail(resultado.Error!);

        var usuario = resultado.Value;
        await repository.AdicionarAsync(usuario);

        return Result<Guid>.Success(usuario.Id);
    }
}
