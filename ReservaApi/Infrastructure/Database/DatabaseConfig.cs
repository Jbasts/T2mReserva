using Npgsql;
using System.Data;

namespace ReservaT2M.Infrastructure.Database
{
    public static class DatabaseConfig
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(connectionString));
        }
    }

}
