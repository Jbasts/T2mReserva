using Dapper;
using Npgsql;
using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;
using System.Data;

namespace ReservaT2M.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly string _connectionString;

        public HotelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public async Task AddAsync(Hotel hotel)
        {
            var sql = "INSERT INTO Hotel (Nome, Endereco, Numero_Quartos) VALUES (@Nome, @Endereco, @NumeroQuartos)";
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(sql, hotel);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Hotel WHERE Id = @Id";
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            var sql = "SELECT * FROM Hotel";
            using (var connection = Connection)
            {
                return await connection.QueryAsync<Hotel>(sql);
            }
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Hotel WHERE Id = @Id";
            using (var connection = Connection)
            {
                return await connection.QueryFirstOrDefaultAsync<Hotel>(sql, new { Id = id });
            }
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            var sql = "UPDATE Hotel SET Nome = @Nome, Endereco = @Endereco, Numero_Quartos = @NumeroQuartos WHERE Id = @Id";
            using (var connection = Connection)
            {
                await connection.ExecuteAsync(sql, hotel);
            }
        }
    }
}
