using FinanceApp.Shared;
using MediatR;

namespace FinanceApp.Usuarios.Application.Usuarios.Commands;

public record RegistrarUsuarioCommand(string Nome, string Email) : IRequest<Result<Guid>>;

