namespace DesignPatterns.Creationals.Factory
{
    public interface IReportGenerator
    {
        void Generate(List<string> data);
    }

    public class PdfReportGenerator : IReportGenerator
    {
        public void Generate(List<string> data)
        {
            Console.WriteLine("Gerando PDF...");
        }
    }

    public class ExcelReportGenerator : IReportGenerator
    {
        public void Generate(List<string> data)
        {
            Console.WriteLine("Gerando Excel...");
        }
    }

    public class CsvReportGenerator : IReportGenerator
    {
        public void Generate(List<string> data)
        {
            Console.WriteLine("Gerando CSV...");
        }
    }
}
