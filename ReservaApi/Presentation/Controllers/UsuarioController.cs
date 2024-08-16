using Microsoft.AspNetCore.Mvc;
using ReservaT2M.Application.DTOs;
using ReservaT2M.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
    {
        var usuarios = await _usuarioService.ObterUsuariosAsync();
        return Ok(usuarios.Select(u => new UsuarioDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email,
            Telefone = u.Telefone
        }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
    {
        var usuario = await _usuarioService.ObterUsuarioPorIdAsync(id);
        if (usuario == null)
            return NotFound();

        return Ok(new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Telefone = usuario.Telefone
        });
    }

    [HttpPost]
    public async Task<ActionResult> CreateUsuario(UsuarioDto usuarioDto)
    {
        var usuario = new Usuario
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
            Telefone = usuarioDto.Telefone
        };

        await _usuarioService.CriarUsuarioAsync(usuario);
        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuarioDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUsuario(int id, UsuarioDto usuarioDto)
    {
        var usuario = new Usuario
        {
            Id = id,
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
            Telefone = usuarioDto.Telefone
        };

        await _usuarioService.AtualizarUsuarioAsync(id, usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUsuario(int id)
    {
        await _usuarioService.DeletarUsuarioAsync(id);
        return NoContent();
    }
}
