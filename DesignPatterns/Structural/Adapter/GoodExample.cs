namespace DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// Agora o serviço pode receber por composição qualquer serviço de envio de e-mail que respeito o contrato do IEmailSender.
    /// Podemos testar a lógica tranquilamento, realizando mocks e respeitamos o OCP!
    /// E se surgir um novo tipo de sender? É só implementar um novo IEmailSender e injetá-lo no EmailService e vai funcionar como sempre!
    /// </summary>
    public class EmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            _emailSender.Send(destinatario, assunto, mensagem);
        }
    }

    public interface IEmailSender
    {
        void Send(string to, string subject, string body);
    }

    public class SendGridAdapter : IEmailSender
    {
        // private readonly SendGridApi _sendGridApi = new SendGridApi();

        public void Send(string to, string subject, string body)
        {
            var parametros = new Dictionary<string, string>
        {
            {"to", to},
            {"subject", subject},
            {"body", body}
        };

            // _sendGridApi.ExecuteSend(parametros);
        }
    }

}
