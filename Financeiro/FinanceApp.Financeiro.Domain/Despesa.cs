using FinanceApp.Shared;

namespace FinanceApp.Financeiro.Domain;

public class Despesa
{
    public Guid Id { get; }
    public Guid UsuarioId { get; }
    public string Categoria { get; }
    public decimal Valor { get; }
    public DateTime Data { get; }
    public string Descricao { get; }

    private Despesa(Guid id, Guid usuarioId, string categoria, decimal valor, DateTime data, string descricao)
    {
        Id = id;
        UsuarioId = usuarioId;
        Categoria = categoria;
        Valor = valor;
        Data = data;
        Descricao = descricao;
    }

    public static Result<Despesa> Criar(Guid usuarioId, string categoria, decimal valor, DateTime data, string descricao)
    {
        if (valor <= 0)
            return Result<Despesa>.Fail("O valor da despesa deve ser maior que zero.");

        if (data > DateTime.Now)
            return Result<Despesa>.Fail("A data da despesa não pode ser futura.");

        if (string.IsNullOrWhiteSpace(categoria))
            return Result<Despesa>.Fail("A categoria da despesa não pode ser vazia.");

        var despesa = new Despesa(
            Guid.NewGuid(),
            usuarioId,
            categoria,
            valor,
            data,
            descricao
        );

        return Result<Despesa>.Success(despesa);
    }
}
