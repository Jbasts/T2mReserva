using ReservaT2M.Application.DTOs;
using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;
using ReservaT2M.Domain.Services;

namespace ReservaT2M.Application.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IHotelService _hotelService;

        public ReservaService(IReservaRepository reservaRepository, IHotelService hotelService)
        {
            _reservaRepository = reservaRepository;
            _hotelService = hotelService;   
        }

        public async Task<IEnumerable<Reserva>> ObterReservasAsync()
        {
            return await _reservaRepository.GetAllAsync();
        }

        public async Task<Reserva> ObterReservaPorIdAsync(int id)
        {
            return await _reservaRepository.GetByIdAsync(id);
        }

        public async Task CriarReservaAsync(ReservaDto reservaDto)
        {

            var reserva = new Reserva
            {
                DataCheckIn = reservaDto.DataCheckIn,
                DataCheckOut = reservaDto.DataCheckOut,
                NumeroQuarto = reservaDto.NumeroQuarto,
                HotelId = reservaDto.HotelId ,
                UsuarioId = reservaDto.UsuarioId
            };
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
