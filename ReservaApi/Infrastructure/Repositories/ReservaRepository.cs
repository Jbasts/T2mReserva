using Dapper;
using Npgsql;
using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;
using System.Data;

namespace ReservaT2M.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly string _connectionString;

        public ReservaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public async Task AddAsync(Reserva reserva)
        {
            var sql = "INSERT INTO Reserva (DataCheckIn, DataCheckOut, NumeroQuarto, HotelId, UsuarioId) VALUES (@DataCheckIn, @DataCheckOut, @NumeroQuarto, @HotelId, @UsuarioId) RETURNING Id";
            using (var connection = Connection)
            {
                reserva.Id = await connection.ExecuteScalarAsync<int>(sql, reserva);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Reserva WHERE Id = @Id";
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            var sql = "SELECT * FROM Reserva";
            using (var connection = Connection)
            {
                return await connection.QueryAsync<Reserva>(sql);
            }
        }

        public async Task<Reserva> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Reserva WHERE Id = @Id";
            using (var connection = Connection)
            {
                return await connection.QueryFirstOrDefaultAsync<Reserva>(sql, new { Id = id });
            }
        }

        public async Task UpdateAsync(Reserva reserva)
        {
            var sql = "UPDATE Reserva SET DataCheckIn = @DataCheckIn, DataCheckOut = @DataCheckOut, NumeroQuarto = @NumeroQuarto, HotelId = @HotelId, UsuarioId = @UsuarioId WHERE Id = @Id";
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(sql, reserva);
            }
        }
    }
}
