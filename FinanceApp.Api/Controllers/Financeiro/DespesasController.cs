using FinanceApp.Financeiro.Application.Despesas.Commands;
using FinanceApp.Financeiro.Application.Despesas.Contracts;
using FinanceApp.Financeiro.Application.Despesas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DespesasController(IMediator mediator) : ControllerBase
{
    [HttpGet("{usuarioId:guid}")]
    public async Task<IActionResult> ObterDespesas(Guid usuarioId, [FromQuery] int mes, [FromQuery] int ano)
    {
        var query = new ObterDespesasQuery(usuarioId, mes, ano);
        var resultado = await mediator.Send(query);

        if (!resultado.IsSuccess)
            return BadRequest(new { Erro = resultado.Error });

        return Ok(resultado.Value);
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarDespesa([FromBody] DespesaRequest dto)
    {
        var command = new RegistrarDespesaCommand(
            dto.UsuarioId,
            dto.Categoria,
            dto.Valor,
            dto.Data,
            dto.Descricao ?? string.Empty
        );

        var resultado = await mediator.Send(command);

        if (!resultado.IsSuccess)
            return BadRequest(new { Erro = resultado.Error });

        return CreatedAtAction(nameof(RegistrarDespesa), new { id = resultado.Value }, new { Id = resultado.Value });    }
}
