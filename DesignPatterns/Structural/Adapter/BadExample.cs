namespace DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// Note que aqui temos um alto acoplamento com o SDK do SendGrid.
    /// E se ele mudar? E se tivermos que mudar o envio de e-mails?
    /// E se os parâmetros de um novo envio forem diferentes?
    /// E para testes? Não temos como mockar o comportamento do SDK do Sendgrid.
    /// O ideal seria termos isso segregado de forma a ficar fácil de modificar.
    /// O serviço de e-mails não precisa conhecer o sdk, ele pode só receber por composição o "Sender" e usá-lo!
    /// </summary>
    public class EmailServiceBadExample
    {
        public void EnviarEmail(string to, string subject, string message)
        {
            //var sendGrid = new SendGridApi();

            var parameters = new Dictionary<string, string>
        {
            {"to", to},
            {"subject", subject},
            {"body", message}
        };

            //sendGrid.ExecuteSend(parameters);
        }
    }
}
