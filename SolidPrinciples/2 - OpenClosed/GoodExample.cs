using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OpenClosed
{
    /// <summary>
    /// Note que a classe IDiscount tem seu comportamento de Calcular.
    /// Já suas classes derivadas também o tem, mas implementam sua maneira de calcular.
    /// Sempre que houver a necessidade de um novo desconto, uma nova classe será criada, mantendo o que as já existentes fazem
    /// Poderiamos usar uma classe ao invés da interface também, porém a Interface mantém o código ainda mais flexivel e de fácil manutentenção (em testes unitários isso aqui salva demais kkkkk)
    /// </summary>
    public interface IDiscount
    {
        public decimal Calculate(decimal value);
    }

    public class ChristmasDiscount : IDiscount
    {
        public decimal Calculate(decimal value)
        {
            return value * 0.8m;
        }
    }

    public class VIPClientDiscount : IDiscount
    {
        public decimal Calculate(decimal value)
        {
            return value * 0.9m;
        }
    }
}
