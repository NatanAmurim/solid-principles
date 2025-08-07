using IntegrationTestLab.Domain;
using IntegrationTestLab.Domain.Interfaces;

namespace IntegrationTestLab.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly IEmailNotifier _notifier;

        public UserService(IUserRepository repository, IEmailNotifier notifier)
        {
            _repository = repository;
            _notifier = notifier;
        }

        public void Register(string name, string email)
        {
            if (!email.Contains("@"))
                throw new ArgumentException("email inválido");

            var user = new User(name, email);
            _repository.Save(user);

            _notifier.Send(email, "Bem vindo!", $"Olá, {name}!");
        }
    }
}
