using Dapper;
using Npgsql;
using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;
using System.Data;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string _connectionString;

    public UsuarioRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));
    }

    private IDbConnection Connection => new NpgsqlConnection(_connectionString);

    public async Task AddAsync(Usuario usuario)
    {
        var sql = "INSERT INTO Usuario (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)";
        using (var connection = Connection)
        {
            await connection.ExecuteAsync(sql, usuario);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM Usuario WHERE Id = @Id";
        using (var connection = Connection)
        {
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        var sql = "SELECT * FROM Usuario";
        using (var connection = Connection)
        {
            return await connection.QueryAsync<Usuario>(sql);
        }
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Usuario WHERE Id = @Id";
        using (var connection = Connection)
        {
            return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        var sql = "UPDATE Usuario SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE Id = @Id";
        using (var connection = Connection)
        {
            await connection.ExecuteAsync(sql, usuario);
        }
    }
}
