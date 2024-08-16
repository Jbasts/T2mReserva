using ReservaT2M.Domain.Entities;

namespace ReservaT2M.Domain.Repositories
{
    public interface IHotelRepository
    {
        Task<Hotel> GetByIdAsync(int id);
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task AddAsync(Hotel hotel);
        Task UpdateAsync(Hotel hotel);
        Task DeleteAsync(int id);
    }
}

