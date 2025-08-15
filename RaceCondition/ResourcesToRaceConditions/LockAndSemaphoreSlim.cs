namespace RaceCondition.ResourcesToRaceConditions
{
    public class LockAndSemaphoreSlim
    {
        /// <summary>
        /// Aqui temos um exemplo de race condition, duas ou mais threads irão acessar o count ao mesmo tempo o que fará com que o resultado não seja o esperado.
        /// </summary>
        public async Task RaceConditionExample()
        {
            int count = 0;

            var tasks = Enumerable.Range(0, 1000).Select(async i =>
            {
                // Simula um trabalho que demora um tempo
                await Task.Delay(1);
                count++;
            });

            await Task.WhenAll(tasks);

            Console.WriteLine($"Sem proteção: {count}");
        }

        /// <summary>
        /// O lock garante que apenas uma thread por vez execute o código dentro dele.
        /// Assim garatindo que apenas uma thread acessará os recursos dentro do lock.
        /// Ideal para código síncrono, mas não recomendado para operações assíncronas, pois bloqueia a thread até que o recurso seja liberado.
        /// </summary>
        public async Task HowToResolveWithLock()
        {
            int count = 0;
            object locker = new object();

            var tasks = Enumerable.Range(0, 1000).Select(async i =>
            {
                await Task.Delay(1);

                lock (locker) // Apenas uma thread de cada vez entra aqui
                {
                    count++;
                }
            });

            await Task.WhenAll(tasks);

            Console.WriteLine($"Com lock: {count}"); // Sempre 1000
        }

        /// <summary>
        ///  O SemaphoreSlim controla quantas threadss podem acessar um recurso simultaneamente.
        /// Caso outra thread tente, ela não conseguirá e ficará na fila, assim que o SemaphoreSlim for liberado (Release), a próxima thread poderá acessar.
        /// Aqui, configurado com 1, ele funciona como um lock, mas de forma assíncrona.
        /// </summary>
        public async Task HowToResolveWithSemaphoreSlim()
        {
            int count = 0;
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1); // Só 1 thread de cada vez

            var tasks = Enumerable.Range(0, 1000).Select(async i =>
            {
                await semaphoreSlim.WaitAsync(); // Espera de forma assíncrona

                try
                {
                    await Task.Delay(1);
                    count++;
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            });

            await Task.WhenAll(tasks);

            Console.WriteLine($"Com SemaphoreSlim: {count}"); // Sempre 1000
        }

    }
}
