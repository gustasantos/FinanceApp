using System;
using FinanceApp.Shared;

namespace FinanceApp.Usuarios.Domain;

public class Usuario
{
    public Guid Id { get; }
    public string Nome { get; }
    public string Email { get; }

    private Usuario(Guid id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public static Result<Usuario> Criar(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return Result<Usuario>.Fail("Nome não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(email))
            return Result<Usuario>.Fail("Email não pode ser vazio.");

        if (!email.Contains('@'))
            return Result<Usuario>.Fail("O email informado não é válido.");

        var usuario = new Usuario(Guid.NewGuid(), nome, email);
        return Result<Usuario>.Success(usuario);
    }

    public Result Deletar()
    {
        if (Email == "admin@financeapp.com")
            return Result.Fail("Não é permitido remover o usuário administrador.");
        
        return Result.Success();
    }
}
