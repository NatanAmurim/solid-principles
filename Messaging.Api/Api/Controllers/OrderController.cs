using Messaging.Api.Application;
using Messaging.Api.Controllers.DTOs;
using Messaging.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Messaging.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderMessagingHandler _orderMessagingHandler;

        public OrderController(ILogger<OrderController> logger, OrderMessagingHandler orderMessagingHandler)
        {
            _logger = logger;
            _orderMessagingHandler = orderMessagingHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequest orderRequest, CancellationToken cancellationToken)
        {
            var order = new Order(orderRequest.Customer, orderRequest.Amount);

            await _orderMessagingHandler.PublishOrderAsync(order, cancellationToken);

            return Ok();
        }
    }
}
