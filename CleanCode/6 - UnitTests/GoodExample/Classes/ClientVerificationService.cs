using CleanCode.UnitTests.Common;

namespace CleanCode.UnitTests.GoodExample.Classes
{
    /// <summary>
    /// Aqui temos um coesão maior.
    /// A classe de serviço apenas orquestra a verificação, chamando as validadoras.
    /// Cada serviço tem sua função e as regras de negócio estão dentro de cada um.
    /// O orquestrador aqui não tem que validar um dado em específico, ele tem que dar o resultado final de validação.
    /// Perceba que o nível de abstração é o mesmo dentro desse contexto.
    /// Cada chamada tem sua responsabilidade de validação e seu resultado.
    /// O orquestrador só tem que chamar e devolver o resultado, não realizar validações.
    /// Com isso, temos um maior desacoplamento e cada teste unitário terá apenas que validar o comportamento
    /// de cada classe.
    /// Aqui atuamos principalmento com o S do Solid, com separação de responsabilidades!
    /// </summary>
    public class ClientVerificationService
    {
        private readonly ClientExistenceValidator _existenceValidator;
        private readonly ScoreValidator _scoreValidator;
        private readonly ProofOfAddressValidator _addressValidator;
        private readonly IClientRepository _clientRepo;

        public ClientVerificationService(
            ClientExistenceValidator existenceValidator,
            ScoreValidator scoreValidator,
            ProofOfAddressValidator addressValidator,
            IClientRepository clientRepo)
        {
            _existenceValidator = existenceValidator;
            _scoreValidator = scoreValidator;
            _addressValidator = addressValidator;
            _clientRepo = clientRepo;
        }

        public VerificationResult Verify(string cpf)
        {
            var (exists, client, existenceResult) = _existenceValidator.Validate(cpf);
            if (!exists) 
                return existenceResult;

            var scoreResult = _scoreValidator.Validate(cpf);
            if (scoreResult != null) 
                return scoreResult;

            var addressResult = _addressValidator.Validate(cpf);
            if (addressResult != null) 
                return addressResult;

            client.Verified = true;
            _clientRepo.Save(client);

            return VerificationResult.Ok("Cliente verificado com sucesso.");
        }
    }
}
