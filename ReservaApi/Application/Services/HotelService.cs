using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;

public class HotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task CriarHotelAsync(Hotel hotel)
    {
        await _hotelRepository.AddAsync(hotel);
    }

    public async Task<IEnumerable<Hotel>> ObterHoteisAsync()
    {
        return await _hotelRepository.GetAllAsync();
    }

    public async Task<Hotel> ObterHotelPorIdAsync(int id)
    {
        return await _hotelRepository.GetByIdAsync(id);
    }

    public async Task AtualizarHotelAsync(int id, Hotel hotel)
    {
        await _hotelRepository.UpdateAsync(hotel);
    }

    public async Task DeletarHotelAsync(int id)
    {
        await _hotelRepository.DeleteAsync(id);
    }
}
