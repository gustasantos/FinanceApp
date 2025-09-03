using System;
using FinanceApp.Usuarios.Domain;

namespace FinanceApp.Usuarios.Infrastructure.Repository;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ObterTodos();
    Task<Usuario?> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(Usuario usuario);
    Task RemoverAsync(Usuario usuario);
}
