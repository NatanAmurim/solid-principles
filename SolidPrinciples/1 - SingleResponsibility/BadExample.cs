namespace SolidPrinciples.SingleResponsibility
{
    /// <summary>
    /// Perceba que essa classe quebra o SRP, pois faz duas coisas. 
    /// Se ela fosse um serviço orquestrador, o correto seria receber por injeção de dependência os serviços de gerar relatório e enviar e-mail.
    /// Assim, o único papel dela seria orquestrar o relatório!
    /// </summary>
    public class ReportService
    {
        public void GenerateReport() {/* lógica */ }
        public void SendEmail() {/* lógica */ }
    }
}
