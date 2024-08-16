using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;

namespace ReservaT2M.Application.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<Reserva>> ObterReservasAsync()
        {
            return await _reservaRepository.GetAllAsync();
        }

        public async Task<Reserva> ObterReservaPorIdAsync(int id)
        {
            return await _reservaRepository.GetByIdAsync(id);
        }

        public async Task CriarReservaAsync(Reserva reserva)
        {
            await _reservaRepository.AddAsync(reserva);
        }

        public async Task AtualizarReservaAsync(int id, Reserva reserva)
        {
            reserva.Id = id;
            await _reservaRepository.UpdateAsync(reserva);
        }

        public async Task DeletarReservaAsync(int id)
        {
            await _reservaRepository.DeleteAsync(id);
        }
    }
}
