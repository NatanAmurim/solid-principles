namespace CleanCode.Introduction
{
    public class ClientServiceBadExample
    {
        public void Process(Client client)
        {
            // valida o cliente
            if (client.Id <= 0 || string.IsNullOrEmpty(client.Name))
            {
                throw new Exception("Cliente inválido");
            }

            // calcula desconto
            var discount = 0.0m;
            if (client.Loyalty > 5)
            {
                discount = 0.1m;
            }

            // aplica desconto
            client.Order.Value -= client.Order.Value * discount;

            // salva no banco
            //repositoy.Save(client.Order);
        }
    }

    /// <summary>
    /// Note que o código cresceu, mas cada função tem um bom nome, é pequena e realiza uma única coisa!
    /// Qualquer um que for fazer manutenção nesse código o entenderá facilmente.
    /// E para realizar testes unitários, basta realizar o teste de cada função.    
    /// </summary>
    public class ClientServiceGoodExample
    {
        public void ProcessClient(Client client)
        {
            ValidateClient(client);

            ApplyDiscount(client);

            SaveClient(client);
        }

        private static void ValidateClient(Client client)
        {
            if (client.Id <= 0 || string.IsNullOrEmpty(client.Name))
            {
                throw new Exception("Cliente inválido");
            }
        }

        private static void SaveClient(Client client)
        {
            /* Lógica para salvar em banco*/
        }

        private static void ApplyDiscount(Client client)
        {
            decimal discount = GetDiscountByLoyalty(client);            
            CalculateDiscount(client, discount);
        }

        private static void CalculateDiscount(Client client, decimal discount)
        {
            client.Order.Value -= client.Order.Value * discount;
        }

        private static decimal GetDiscountByLoyalty(Client client)
        {
            var discount = 0.0m;

            if (client.Loyalty > 5)            
                discount = 0.1m;            

            return discount;
        }


    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Loyalty { get; set; }
        public Order Order { get; set; }
    }

    public class Order
    {
        public decimal Value { get; set; }
    }
}
