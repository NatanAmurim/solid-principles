using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCondition.TasksExamples
{
    internal class TaskRunExample
    {
        public async Task Example()
        {
            //Aqui jogamos para uma thread em paralelo o processamento CPU-bound
            //Muito útil para trabalhar com operações síncronas em cenários assíncronos, evitando o bloqueio da thread principal.
            await Task.Run(() =>
            {
                // Trabalho pesado
                for (int i = 0; i < 1_000_000; i++) ;
                Console.WriteLine("Processamento concluído!");
            });
        }
    }
}
