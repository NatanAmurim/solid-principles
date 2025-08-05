using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.EmergentDesign
{
    /// <summary>
    /// Aqui nosso sistema começa simples, porém com bons princípios de design!
    /// Temos um design pattern de Factory para criar os geradores de relatórios de acordo com seu tipo.
    /// Se um novo tipo surgir, só alteramos a fábrica! O serviço que chama o gerador de relatório permanece intacto, assim como os geradores pré-existentes.
    /// Os testes permanecem testando unicamente a funcionalidade de cada gerador, sem quebrar nada.
    /// Se alterações forem feitas em algum gerador, sem problema, os demais estão isolados, logo temos a certeza que não será afetados.   
    /// </summary>
    public interface IReportFormatter
    {
        string Format(List<string> data);
    }

    public class ReportService
    {
        public string GenerateReport(string type, List<string> data)
        {
            var formatter = ReportGeneratorFactory.GetReportGeneratorByType(type);            

            return formatter.Format(data);
        }
    }


    public static class ReportGeneratorFactory
    {
        public static IReportFormatter GetReportGeneratorByType(string type)
        {
            return type.ToUpper() switch
            {
                "CSV" => new CsvReportFormatter(),
                "JSON" => new JsonReportFormatter(),
                //"XML" => new XmlReportFormatter(), Se vier a existir, só aqui é alterado!
                _ => throw new ArgumentException("Tipo de relatório inválido")
            };
        }
    }

    public class CsvReportFormatter : IReportFormatter
    {
        public string Format(List<string> data)
        {
            return string.Join(",", data);
        }
    }

    public class JsonReportFormatter : IReportFormatter
    {
        public string Format(List<string> data)
        {
            return "[" + string.Join(",", data.Select(d => $"\"{d}\"")) + "]";
        }
    }
}
