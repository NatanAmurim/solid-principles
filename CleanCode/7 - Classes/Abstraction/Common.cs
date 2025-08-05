namespace CleanCode.Classes.Abstraction
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }

    public class Item
    {
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Total { get; set; }

    }

    public class Customer
    {
        public string Name { get; set; }
    }

    public class OrderSender
    {
        public void Send(Order order)
        {
            throw new NotImplementedException();
        }
    }

    public class PriceCalculator
    {
        public void Calculate(Order order)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderValidator
    {
        public void Validate(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
