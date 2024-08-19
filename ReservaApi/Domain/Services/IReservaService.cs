using ReservaT2M.Application.DTOs;

namespace ReservaT2M.Domain.Services
{
    public interface IReservaService
    {
        Task<IEnumerable<Reserva>> ObterReservasAsync();


        Task<Reserva> ObterReservaPorIdAsync(int id);

        Task CriarReservaAsync(ReservaDto reservaDto);

        Task AtualizarReservaAsync(int id, Reserva reserva);

        Task DeletarReservaAsync(int id);
       
    }
}
