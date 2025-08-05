using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Commentaries
{
    namespace CleanCode.Comments.GoodExample
    {
        /// <summary>
        /// Note que essa classe não tem necessidade de tantos comentários, cada método diz o que faz e isso é suficiente!
        /// No caso do SaveOrder temos um bom comentário com um TODO, pois não temos lógica e precisamos deixar claro isso.
       
        /// </summary>
        public class OrderService
        {
            public void CreateOrder(Order order)
            {
                ValidateClient(order.Client);

                CalculateOrderTotal(order);

                SaveOrder(order);
            }

            private void ValidateClient(Client client)
            {
                if (client == null || string.IsNullOrWhiteSpace(client.Name))
                    throw new ArgumentException("Cliente inválido.");
            }

            private void CalculateOrderTotal(Order order)
            {
                order.Total = order.Items.Sum(item => item.Price * item.Quantity);
            }

            private void SaveOrder(Order order)
            {
                // Aqui será utilizado um ORM no futuro, mas por enquanto isso é simulado.
                // TODO: integrar com o repositório real. E remover esses comentários depois disso para não ficarem obsoletos.
            }

            
            ///Note que abaixo temo um bom exemplo de comentário, pois ele diz o motivo do código existir, trata-se de uma regra de negócio.
            ///Nesse caso, o código está claro no que faz, mas não do porque faz. Então o comentário é bem vindo!
            /// Aplicamos 10% de desconto para clientes VIPs com mais de 3 pedidos ativos
            private decimal GetDiscount(Client client)
            {
                if (client.IsVip && client.ActiveOrders > 3)
                    return 0.10m;

                return 0m;
            }
        }

        public class Order
        {
            public Client Client { get; set; }
            public List<Item> Items { get; set; } = new();
            public decimal Total { get; set; }            
        }

        public class Client
        {
            public string Name { get; set; }
            public bool IsVip { get; set; }
            public int ActiveOrders { get; set; }
        }

        public class Item
        {
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
