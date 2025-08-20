namespace Messaging.Api.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Customer { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Order(string customer, decimal amount)
        {
            Customer = customer;
            Amount = amount;
        }

    }
}
