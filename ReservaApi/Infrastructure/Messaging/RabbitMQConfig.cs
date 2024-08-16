using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
namespace ReservaT2M.Infrastructure.Messaging
{
    public static class RabbitMQConfig
    {
        public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var factory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMQ:HostName"]
            };
            services.AddSingleton(factory);
            services.AddSingleton(sp => factory.CreateConnection());
            services.AddSingleton(sp => sp.GetRequiredService<IConnection>().CreateModel());
        }
    }
}

