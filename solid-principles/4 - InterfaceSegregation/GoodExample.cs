using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.InterfaceSegregation
{
    /// <summary>
    /// Note que cada interface tem apenas métodos correspontes a suas funcionalidades.
    /// E cada classe que for implementar, pode escolher aquilo que lhe faz sentido, assim evitando implementações não desejadas e evitando erros não esperados.
    /// </summary>
    public interface IPrinter
    {
        public void Print();
    }

    public interface IScanner
    {
        public void Scan();
    }

    public class PrinterWithScanner() : IPrinter, IScanner
    {
        public void Print()
        {
            /*Lógica de impressão */
        }

        public void Scan()
        {
            /*Lógica de escaneamento */
        }
    }

    public class Printer() : IPrinter
    {
        public void Print()
        {
            /*Lógica de impressão */
        }
    }

    public class Scanner() : IScanner
    {
        public void Scan()
        {
            /*Lógica de escaneamento */
        }
    }
}
