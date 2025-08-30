using FinanceApp.Usuarios.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Usuarios.Infrastructure.Repository;

public class UsuarioRepository(UsuarioDbContext context) : IUsuarioRepository
{
    public Task AdicionarAsync(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        return context.SaveChangesAsync();
    }

    public async Task<Usuario?> ObterPorIdAsync(Guid id)
    {
        return await context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
