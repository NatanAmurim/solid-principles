namespace Messaging.Api.Controllers.DTOs
{
    public class OrderRequest
    {
        public string Customer { get; set; }
        public decimal Amount { get; set; }
    }
}
