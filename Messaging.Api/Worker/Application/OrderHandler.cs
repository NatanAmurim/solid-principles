namespace Messaging.Worker.Application
{
    public class OrderHandler(ILogger<OrderHandler> logger)
    {
        public async Task OrderHandle(string message)
        {
            logger.LogInformation(message);
        }
    }
}
