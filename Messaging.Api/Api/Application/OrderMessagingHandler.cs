using Messaging.Api.Domain.Entities;
using Messaging.Api.Domain.Infra;

namespace Messaging.Api.Application
{
    public class OrderMessagingHandler(IOrderMessagingBroker orderMessagingBroker)
    {
        public async Task PublishOrderAsync(Order order, CancellationToken cancellationToken)
        {
            await orderMessagingBroker.PublishOrder(order, cancellationToken);
        }
    }
}
