using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Classes.Abstraction
{
    /// <summary>
    /// Veja como mudou! Essa classe apenas funciona como uma orquestradora.
    /// Todas suas chamadas estão no mesmo nível de abstração.
    /// Para testes, manutenção e possíveis mudanças, isso é muito melhor!

    /// </summary>
    public class OrderProcessor
    {
        private readonly OrderValidator _validator;
        private readonly PriceCalculator _calculator;
        private readonly OrderSender _sender;

        public OrderProcessor(OrderValidator validator, PriceCalculator calculator, OrderSender sender)
        {
            _validator = validator;
            _calculator = calculator;
            _sender = sender;
        }

        public void Process(Order order)
        {
            _validator.Validate(order);
            _calculator.Calculate(order);
            _sender.Send(order);
        }
    }
}
