using FinanceApp.Usuario.Application.Usuarios.Queries;
using FinanceApp.Usuarios.Application.Usuarios.Commands;
using FinanceApp.Usuarios.Application.Usuarios.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers.Usuarios;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ObterTodosUsuarios()
    {
        var query = new ObterUsuariosQuery();
        var resultado = await mediator.Send(query);
        
        if (!resultado.IsSuccess)
            return NotFound(resultado.Error);
        
        return Ok(resultado.Value);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterUsuario(Guid id)
    {
        var query = new ObterUsuarioQuery(id);
        var resultado = await mediator.Send(query);

        if (!resultado.IsSuccess)
            return NotFound(resultado.Error);

        return Ok(resultado.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] UsuarioRequest request)
    {
        var command = new RegistrarUsuarioCommand(request.Nome, request.Email);
        var resultado = await mediator.Send(command);

        if (!resultado.IsSuccess)
            return BadRequest(resultado.Error);

        return CreatedAtAction(nameof(ObterUsuario), new { id = resultado.Value }, resultado.Value);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletarUsuario(Guid id)
    {
        var command = new DeletarUsuarioCommand(id);
        var resultado = await mediator.Send(command);
        
        if(!resultado.IsSuccess)
            return BadRequest(resultado.Error);
        
        return Ok(resultado.Message);
    }
}
