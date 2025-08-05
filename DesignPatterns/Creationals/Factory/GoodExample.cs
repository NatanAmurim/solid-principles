using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creationals.Factory
{
    /// <summary>
    /// Veja que aqui mantemos o código do serviço funcionando da maneira que precisa ser sem alterar seu comportamento!
    /// E se for necessário um novo tipo, somente a factory será alterada, mas por uma única razão, adicionar um novo tipo.
    /// Os demais tipos não sofrem nenhuma alteração!
    /// </summary>
    public class ReportService
    {
        public void ExportReport(string reportType, List<string> data)
        {
            var generator = ReportFactory.Create(reportType);
            generator.Generate(data);
        }
    }

    public static class ReportFactory
    {
        public static IReportGenerator Create(string reportType)
        {
            return reportType.ToUpper() switch
            {
                "PDF" => new PdfReportGenerator(),
                "EXCEL" => new ExcelReportGenerator(),
                "CSV" => new CsvReportGenerator(),
                _ => throw new NotSupportedException("Unsupported report type")
            };
        }
    }
}
