using CleanCode.UnitTests.Common;

namespace CleanCode.UnitTests.GoodExample.Classes
{
    public class ClientExistenceValidator
    {
        private readonly IClientRepository _repo;

        public ClientExistenceValidator(IClientRepository repo)
        {
            _repo = repo;
        }

        public (bool isValid, Client client, VerificationResult result) Validate(string cpf)
        {
            var client = _repo.GetByCPF(cpf);
            if (client == null)
                return (false, null, VerificationResult.Fail("Cliente não encontrado."));

            return (true, client, null);
        }
    }

}
