
namespace FinanceApp.Usuarios.Application.Usuarios.Contracts;

public record UsuarioRequest
{
    public string Nome { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
