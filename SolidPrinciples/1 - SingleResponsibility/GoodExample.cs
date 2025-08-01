namespace SolidPrinciples.SingleResponsibility
{
    /// <summary>
    /// Unicamente tem a responsábilidade de gerar um relatório.
    /// </summary>
    public class ReportGenerator
    {
        public void GenerateReport() {/* lógica */ }
    }

    /// <summary>
    /// Unicamente tem a responsabilidade de enviar um e-mail.
    /// </summary>
    public class EmailSender()
    {
        public void SendEmail() {/* lógica */ }
    }
}
