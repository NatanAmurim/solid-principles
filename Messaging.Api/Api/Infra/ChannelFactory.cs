using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Data.Common;
using System.Threading.Channels;

namespace Messaging.Api.Infra
{
    public class ChannelFactory
    {
        private IConnection _connection;        


        private async Task<IConnection> CreateConnectionAsync()
        {
            if (_connection is null)
            {
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

                _connection = await factory.CreateConnectionAsync();
            } 

            return _connection;
        }
        public async Task<IChannel> CreateChannelAsync()
        {
            var connection = await CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "orders",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            return channel;
        }
    }
}
