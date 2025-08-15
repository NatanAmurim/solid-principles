using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCondition.TasksExamples
{
    internal class AwaitExample
    {
        async Task Example()
        {
            Console.WriteLine("Início");
            await Task.Delay(2000); // espera 2s sem bloquear a thread, a liberando para realizar outras operações.
            Console.WriteLine("Fim");
        }
    }
}
