namespace IntegrationTestLab.Domain.Interfaces
{
    public interface IEmailNotifier
    {
        void Send(string to, string subject, string message);
    }
}
