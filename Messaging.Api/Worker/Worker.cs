using Messaging.Api.Infra;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Messaging.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ChannelFactory _channelFactory;
        private readonly string _queueName = "orders";

        public Worker(ILogger<Worker> logger, ChannelFactory channelFactory)
        {
            _logger = logger;
            _channelFactory = channelFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var channel = await _channelFactory.CreateChannelAsync();
            
            //Aqui configuramos o máximo de mensagens que o canal receberá por vez do rabbit.
            await channel.BasicQosAsync(0, prefetchCount: 10, true);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (payload, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation(message);

                await channel.BasicAckAsync(args.DeliveryTag, false);
            };

            await channel.BasicConsumeAsync(_queueName, false, consumer, stoppingToken);
        }
    }
}
