using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.InterfaceSegregation
{
    /// <summary>
    /// Note que essa interface tem muitos métodos, mas nem todas as impressoras tem todas essas funcionalidades.
    /// Logo se uma impressora implementa essa interface, ela é obrigada a implementar todos seus métodos, mesmo não utilizando todos.
    /// Isso viola o InterfaceSegregation.
    /// </summary>
    public interface IMultifunctional
    {
        public void Print();
        public void Scan();
        public void Fax();
    }

    public class SimplePrinter() : IMultifunctional
    {
        public void Fax()
        {
            throw new Exception("Estamos em 1980?");
        }

        public void Print()
        {
            /*Lógica de impressão */
        }

        public void Scan()
        {
            /*Lógica de escaneamento */
        }
    }
}
