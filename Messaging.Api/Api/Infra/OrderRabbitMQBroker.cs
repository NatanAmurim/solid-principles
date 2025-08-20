using Messaging.Api.Domain.Entities;
using Messaging.Api.Domain.Infra;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Messaging.Api.Infra
{
    public class OrderRabbitMQBroker(ChannelFactory channelFactory) : IOrderMessagingBroker
    {
        private readonly string _queueName = "orders";

        public async Task PublishOrder(Order order, CancellationToken cancellationToken)
        {
            try
            {
                var orderInJsonBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(order));
                var props = new BasicProperties() { Persistent = true };

                var channel = await channelFactory.CreateChannelAsync();

                await channel.BasicPublishAsync(exchange: "", routingKey: _queueName, true, basicProperties: props, body: orderInJsonBytes, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                //Alguma tratativa mais log
                Console.WriteLine($"Erro ao gerar mensagem.Erro:{ex.Message}");
            }
        }
    }
}
