using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    /// <summary>
    /// Veja que se um novo comportamento surgir, um novo tipo de entrega, teremos que alterar essa classe.
    /// Isso pode gerar um bug, pois estamos mexendo em um sistema que já está funcionando.
    /// Ao aplicar o Strategy, respeitamos o SRP e OCP! Além de facilitar a manutenção.
    /// </summary>
    public class ShippingCalculatorBadExample
    {
        public decimal CalculateShipping(string shippingType, decimal orderAmount)
        {
            if (shippingType == "Regular")
            {
                // Frete fixo
                return 10m;
            }
            else if (shippingType == "FreeOver100")
            {
                // Frete grátis para pedidos acima de 100
                return orderAmount > 100 ? 0m : 10m;
            }
            else if (shippingType == "Express")
            {
                // Frete expresso, taxa fixa maior
                return 20m;
            }
            else
            {
                throw new ArgumentException("Tipo de frete inválido");
            }
        }
    }
}
