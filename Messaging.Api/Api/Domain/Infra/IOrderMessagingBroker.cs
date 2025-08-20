using Messaging.Api.Domain.Entities;

namespace Messaging.Api.Domain.Infra
{
    public interface IOrderMessagingBroker
    {
        public Task PublishOrder(Order order, CancellationToken cancellationToken);
    }
}
