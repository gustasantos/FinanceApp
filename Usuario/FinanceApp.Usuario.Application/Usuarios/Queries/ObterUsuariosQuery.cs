using FinanceApp.Shared;
using FinanceApp.Usuarios.Application.Usuarios.Contracts;
using MediatR;

namespace FinanceApp.Usuario.Application.Usuarios.Queries;

public record ObterUsuariosQuery : IRequest<Result<List<UsuarioResponse>>>;

    
