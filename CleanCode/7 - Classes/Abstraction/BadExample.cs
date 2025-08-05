namespace CleanCode.Classes.Abstraction
{
    /// <summary>
    /// Essa classe faz mais do que deveria.
    /// A ideia dela é ser um orquestrador, porém mistura responsabilidades e níveis de abstração.
    /// Ela valida o cliente (regra de domínio), faz cálculo de items (lógica de negócio) e envia a um sistema externo (infraestrutura).
    /// Isso dificulta testes, manutenção e reaproveitamento.
    /// </summary>
    public class OrderProcessorBadExample
    {               
        public void Process(Order order)
        {
            if (order.Customer == null || string.IsNullOrEmpty(order.Customer.Name))
            {
                throw new Exception("Cliente inválido");
            }

            foreach (var item in order.Items)
            {
                item.Total = item.Quantity * item.UnitPrice;
            }

            // Enviar para sistema externo
            // xpto.Send(order);
        }
    }
}
