// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

var benchmarks = new Benchmarks();

Console.WriteLine("Gerando lixo...");

for (int i = 0; i < 10000; i++)
{
    var lixo = new byte[1024 * 1024]; // cria 1MB de lixo a cada volta
}

Console.WriteLine("Fim! Pressione Enter para sair.");
Console.ReadLine();

Console.WriteLine(benchmarks.ToString());

//BenchmarkRunner.Run<Benchmarks>();

/// <summary>
/// Mean: Tempo médio das execuções.
/// StdDev: Desvio padrão que mostra o quanto os tempos individuais se afastam da média.
/// Error: Erro padrão da média que é uma estimativa de quanto a média pode variar, calculado com base no StdDev e no número de execuções.
/// Gen0: Quantas vezes o Garbage Collector de geração 0 foi acionado.
/// Gen1: Quantas vezes o Garbage Collector de geração 1 foi acionado.
/// Allocated: Quantidade total de memória alocada para realizar a tarefa (em KB).
/// </summary>
[MemoryDiagnoser]
public class Benchmarks
{
    private const int N = 1000;

    [Benchmark]
    public string ConcatenationWithPlus()
    {
        string result = "";
        for (int i = 0; i < N; i++)
            result += i;
        return result;
    }

    [Benchmark]
    public string ConcatenationWithStringBuilder()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < N; i++)
            sb.Append(i);
        return sb.ToString();
    }
}