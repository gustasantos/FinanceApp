using FinanceApp.Shared;
using MediatR;

namespace FinanceApp.Usuarios.Application.Usuarios.Commands;

public record DeletarUsuarioCommand(Guid UsuarioId) : IRequest<Result>;