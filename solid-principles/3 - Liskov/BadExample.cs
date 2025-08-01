using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Liskov
{
    /// <summary>
    /// Perceba que aqui ocorre a violção de Liskov, pois a classe derivada quebra o fluxo esperado. 
    /// Uma classe derivada da classe Ave, deveria voar, porém o pinguim não voa. Só quando o Batman joga ele pra longe kkkkk.   
    /// </summary>
    public class BadBird
    {
        public virtual void Fly() { }
    }

    public class BadPenguin : BadBird
    {
        public override void Fly() 
        { 
            throw new Exception("Pinguins não voam!");
        }
    }
}
