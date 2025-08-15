using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCondition.ResourcesToRaceConditions
{
    public class ConcurrencyExamples
    {
        /// <summary>
        /// Aqui diversas threads irão acessar o dicionário, adicionando/atualizando itens de maneira concorrente.
        /// ConcurrentDictionary é thread-safe, ou seja, ele administra essa inserção de maneira a trabalhar com múltiplas threads 
        /// sem correr riscos de inconsistências ou lançamento de exceções por conta de mais de um thread acessar um recurso.        
        /// </summary>
        public void ConcurrentDictionaryExample()
        {
            var dict = new ConcurrentDictionary<string, int>();

            Parallel.For(0, 1000, i =>
            {
                dict.AddOrUpdate("contador", 1, (key, oldValue) => oldValue + 1);
            });

            Console.WriteLine($"Total: {dict["contador"]}");
        }

        /// <summary>
        /// Diversas threads podem acessar a fila simultaneamente, enfileirando ou retirando itens de maneira segura.
        /// O ConcurrentQueue é thread-safe e garante que cada item seja retirado na ordem em que foi adicionado (FIFO),
        /// mesmo com múltiplas threads acessando a fila ao mesmo tempo.
        /// </summary>
        public void ConcurrentQueue()
        {
            var queue = new ConcurrentQueue<string>();

            // Produtores
            Task.Run(() => queue.Enqueue("Item 1"));
            Task.Run(() => queue.Enqueue("Item 2"));
            Task.Run(() => queue.Enqueue("Item 3"));

            // Consumidores
            Task.Run(() =>
            {
                if (queue.TryDequeue(out string item))
                    Console.WriteLine("Thread 1 retirou: " + item);
            });

            Task.Run(() =>
            {
                if (queue.TryDequeue(out string item))
                    Console.WriteLine("Thread 2 retirou: " + item);
            });

            Task.Delay(500).Wait(); // Espera threads terminarem
        }
    }
}
