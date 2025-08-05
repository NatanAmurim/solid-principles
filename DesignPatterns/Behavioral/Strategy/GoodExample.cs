using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    /// <summary>
    /// Note que aqui a classe de cálculo recebe em seu construtor um tipo de calculo de frete.
    /// Se um novo tipo surgir, ele terá suas regras e será implementado em uma classe separada, assim não afetando as demais classes de cálculo!
    /// Repeitamos o SPR e o OCP! Além de aplicar Liskov e DI!
    /// A criação da classe fica a cargo de um container de DI ou mesmo na Main se for o caso.
    /// </summary>
    public class ShippingCalculator
    {
        private readonly IShippingStrategy _strategy;

        public ShippingCalculator(IShippingStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal CalculateShipping(decimal orderAmount)
        {
            return _strategy.Calculate(orderAmount);
        }
    }

    public interface IShippingStrategy
    {
        decimal Calculate(decimal orderAmount);
    }
    public class RegularShipping : IShippingStrategy
    {
        public decimal Calculate(decimal orderAmount) => 10m;
    }

    public class FreeShippingOver100 : IShippingStrategy
    {
        public decimal Calculate(decimal orderAmount) => orderAmount > 100 ? 0m : 10m;
    }

    public class ExpressShipping : IShippingStrategy
    {
        public decimal Calculate(decimal orderAmount) => 20m;
    }
}
