using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Commentaries
{
    public class BadOrderService
    {
        // Essa função serve para criar um pedido
        public void CreateOrder(Order order)
        {
            // Verifica se o cliente é válido
            if (order.Client == null)
            {
                // lança exceção
                throw new Exception("Cliente inválido");
            }

            // Calcula o valor total
            order.Total = order.Items.Sum(i => i.Price * i.Quantity);

            // Salva no banco de dados
            Save(order);
        }

        // Essa função salva o pedido
        private void Save(Order order)
        {
            // código para salvar
        }
    }

    public class Order
    {
        public Client Client { get; set; }
        public List<Item> Items { get; set; }
        public decimal Total { get; set; }
    }

    public class Client
    {
        public string Name { get; set; }
    }

    public class Item
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
