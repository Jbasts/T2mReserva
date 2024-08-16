using RabbitMQ.Client;
using System.Text;

namespace ReservaT2M.Infrastructure.Messaging
{
    public class RabbitMQPublisher
    {
        private readonly IModel _channel;

        public RabbitMQPublisher(IModel channel)
        {
            _channel = channel;
        }

        public void Publish(string message, string routingKey)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(
                exchange: "ReservaExchange",  // Nome da exchange no RabbitMQ
                routingKey: routingKey,       // Chave de roteamento
                basicProperties: null,        // Propriedades da mensagem
                body: body                    // Corpo da mensagem em bytes
            );
        }
    }
}

