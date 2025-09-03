using FinanceApp.Shared;
using FinanceApp.Usuario.Application.Usuarios.Queries;
using FinanceApp.Usuarios.Application.Usuarios.Contracts;
using FinanceApp.Usuarios.Infrastructure.Repository;
using MediatR;

namespace FinanceApp.Usuarios.Application.Usuarios.Handlers;

public class ObterUsuariosQueryHandler(IUsuarioRepository repository) 
    : IRequestHandler<ObterUsuariosQuery, Result<List<UsuarioResponse>>>
{
    public async Task<Result<List<UsuarioResponse>>> Handle(ObterUsuariosQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await repository.ObterTodos();
        
        if(usuarios is null)
            return Result<List<UsuarioResponse>>.Fail("Nenhum usuario encontrado");

        var response = usuarios
            .Select(u => new UsuarioResponse(u.Id, u.Nome, u.Email))
            .ToList();
        
        return Result<List<UsuarioResponse>>.Success(response);
    }
}