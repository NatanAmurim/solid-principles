using CleanCode.UnitTests.Common;

namespace CleanCode.UnitTests.BadExample.Classes
{
    /// <summary>
    /// Aqui temos um serviço orquestrador.
    /// Note que temos um cenário bem típico de aplicações do dia a dia.
    /// Acontece que nos esse serviço tem regras de negócio misturadas com orquestração (validação).    
    /// Isso torna a classe de testes gigantesca e de difícil compreensão.
    /// Veja os testes unitários desse cara e você vai entender!
    /// </summary>
    public class ClientVerificationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IScoreService _scoreService;
        private readonly IStorageService _storageService;

        public ClientVerificationService(
            IClientRepository clientRepository,
            IScoreService scoreService,
            IStorageService storageService)
        {
            _clientRepository = clientRepository;
            _scoreService = scoreService;
            _storageService = storageService;
        }

        public VerificationResult Verify(string cpf)
        {
            var client = _clientRepository.GetByCPF(cpf);

            if (client == null)
                return VerificationResult.Fail("Cliente não encontrado.");

            var score = _scoreService.GetScore(cpf);

            if (score < 500)
                return VerificationResult.Fail("Score insuficiente.");

            bool documentExists = _storageService.FileExists($"comprovantes/{cpf}.pdf");

            if (!documentExists)
                return VerificationResult.Fail("Comprovante de residência não encontrado.");

            client.Verified = true;
            _clientRepository.Save(client);

            return VerificationResult.Ok("Cliente verificado com sucesso.");
        }
    }
}
