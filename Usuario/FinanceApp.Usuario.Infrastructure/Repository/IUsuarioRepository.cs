using System;
using FinanceApp.Usuarios.Domain;

namespace FinanceApp.Usuarios.Infrastructure.Repository;

public interface IUsuarioRepository
{
    Task AdicionarAsync(Usuario usuario);
    Task<Usuario?> ObterPorIdAsync(Guid id);
}
