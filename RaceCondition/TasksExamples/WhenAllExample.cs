using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCondition.TasksExamples
{
    public class WhenAllExample
    {
        public async Task Example() 
        {
            var tarefa1 = Task.Run(() => Console.WriteLine("Tarefa 1"));
            var tarefa2 = Task.Run(() => Console.WriteLine("Tarefa 2"));
            var tarefa3 = Task.Run(() => Console.WriteLine("Tarefa 3"));

            await Task.WhenAll(tarefa1, tarefa2, tarefa3);

            //Aqui só será executado quando todas as tarefas forem finalizadas!
            Console.WriteLine("Todas as tarefas terminaram!");
        }
    }
}
