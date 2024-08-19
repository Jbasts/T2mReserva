using ReservaT2M.Domain.Entities;

namespace ReservaT2M.Domain.Services
{
    public interface IHotelService
    {
        Task CriarHotelAsync(Hotel hotel);
        Task<IEnumerable<Hotel>> ObterHoteisAsync();
        Task<Hotel> ObterHotelPorIdAsync(int id);
        Task AtualizarHotelAsync(int id, Hotel hotel);
        Task DeletarHotelAsync(int id);

    }

}
