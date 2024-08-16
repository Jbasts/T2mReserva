using ReservaT2M.Domain.Entities;

namespace ReservaT2M.Domain.Repositories
{
    public interface IReservaRepository
    {
        Task<Reserva> GetByIdAsync(int id);
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task AddAsync(Reserva reserva);
        Task UpdateAsync(Reserva reserva);
        Task DeleteAsync(int id);
    }

}
