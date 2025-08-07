using IntegrationTestLab.Domain.Interfaces;

namespace IntegrationTestLab.Services
{
    public class EmailNotifier : IEmailNotifier
    {
        public void Send(string to, string subject, string message)
        {
            /*Lógica de envio de e-mail*/
        }
    }
}
