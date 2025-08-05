namespace DesignPatterns.Creationals.Factory
{
    /// <summary>
    /// Aqui veja que temos uma clara violão de OCP.
    /// Caso surja um novo tipo, teremos que altera essa classe, o que pode impactar o sistema que já está funcionando.
    /// Com o Factory, conseguimos tornar o código mais elegante e de fácil manutenção.
    /// </summary>
    public class ReportServiceBadExample
    {
        public void ExportReport(string reportType, List<string> data)
        {
            if (reportType == "PDF")
            {
                var generator = new PdfReportGenerator();
                generator.Generate(data);
            }
            else if (reportType == "EXCEL")
            {
                var generator = new ExcelReportGenerator();
                generator.Generate(data);
            }
            else if (reportType == "CSV")
            {
                var generator = new CsvReportGenerator();
                generator.Generate(data);
            }
            else
            {
                throw new NotSupportedException("Unsupported report type");
            }
        }
    }
}
