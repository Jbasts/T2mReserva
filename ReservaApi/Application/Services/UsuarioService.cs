using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task CriarUsuarioAsync(Usuario usuario)
    {
        await _usuarioRepository.AddAsync(usuario);
    }

    public async Task<IEnumerable<Usuario>> ObterUsuariosAsync()
    {
        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<Usuario> ObterUsuarioPorIdAsync(int id)
    {
        return await _usuarioRepository.GetByIdAsync(id);
    }

    public async Task AtualizarUsuarioAsync(int id, Usuario usuario)
    {
        usuario.Id = id;
        await _usuarioRepository.UpdateAsync(usuario);
    }

    public async Task DeletarUsuarioAsync(int id)
    {
        await _usuarioRepository.DeleteAsync(id);
    }
}
