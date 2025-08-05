using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.EmergentDesign
{
    /// <summary>
    /// Note que o código funciona, porém ele repete estruturas, é difícil de testar e está muito aberto para modificações, violando o OCP.
    /// Se um novo tipo de arquivo surgir, teremos que alterar o código o que pode gerar um bug em algo que já funcionava bem.
    /// </summary>
    public class ReportGeneratorBadExample
    {
        public string GenerateReport(string type, List<string> data)
        {
            string report = "";

            if (type == "CSV")
            {
                foreach (var item in data)
                {
                    report += item + ",";
                }
                report = report.TrimEnd(',');
            }
            else if (type == "JSON")
            {
                report = "[";
                foreach (var item in data)
                {
                    report += "\"" + item + "\",";
                }
                report = report.TrimEnd(',') + "]";
            }

            return report;
        }
    }
}
