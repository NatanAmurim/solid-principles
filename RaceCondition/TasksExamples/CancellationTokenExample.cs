using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceCondition.TasksExamples
{
    /// <summary>
    /// Aqui temos um exemplo de uso do cancellationToken, interropendo a execução da tarefa caso o cancellation seja chamado
    /// </summary>
    public class CancellationTokenExample
    {        
        public async Task ProcessAsync(CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested(); // cancela se solicitado
                Console.WriteLine($"Processando {i}");
                await Task.Delay(500, token);
            }            
        }
        public async Task RunAsync() 
        {
            var cts = new CancellationTokenSource();
            var task = ProcessAsync(cts.Token);

            //Aqui colocamos uma tarefa pra executar em segundo plano para cancelar a tarefa, simulando um usuário cancelando.
            //Dessa forma, assim que houver o cancelamento, a tarefa ProcessAsync será cancelada.            
            Task.Run(async () =>
            {
                await Task.Delay(1500);
                cts.Cancel();
            });

            try
            {                
                 await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Tarefa cancelada!");
            }

        }
    }
}
