using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;

namespace ReservaT2M.Domain.Services
{
    public interface IUsuarioService
    {
        Task CriarUsuarioAsync(Usuario usuario);

        Task<IEnumerable<Usuario>> ObterUsuariosAsync();

        Task<Usuario> ObterUsuarioPorIdAsync(int id);

        Task AtualizarUsuarioAsync(int id, Usuario usuario);

        Task DeletarUsuarioAsync(int id);

    }
}
