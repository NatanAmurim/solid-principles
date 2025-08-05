using CleanCode.UnitTests.Common;
using CleanCode.UnitTests.GoodExample.Classes;
using Moq;
using NUnit.Framework;

namespace CleanCode.UnitTests.GoodExample.Tests
{
    /// <summary>
    /// Note que aqui temos a validação da chamada dos serviços de validação que foram separados.
    /// Cada testes testa unicamente isso e cada teste de de cada classe de serviço separada tem a responsabilidade de testar suas funcionalidades.
    /// Caso a validação mude, ela mudará no serviço segregado, sem impactar a classe orquestradora ou outras validações.
    /// </summary>
    [TestFixture]
    public class ClientVerificationServiceTests
    {
        private Mock<IClientRepository> _repoMock;
        private Mock<IScoreService> _scoreMock;
        private Mock<IStorageService> _storageMock;

        private ClientExistenceValidator _existenceValidator;
        private ScoreValidator _scoreValidator;
        private ProofOfAddressValidator _addressValidator;
        private ClientVerificationService _service;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IClientRepository>();
            _scoreMock = new Mock<IScoreService>();
            _storageMock = new Mock<IStorageService>();

            _existenceValidator = new ClientExistenceValidator(_repoMock.Object);
            _scoreValidator = new ScoreValidator(_scoreMock.Object);
            _addressValidator = new ProofOfAddressValidator(_storageMock.Object);

            _service = new ClientVerificationService(_existenceValidator, _scoreValidator, _addressValidator, _repoMock.Object);
        }

        [Test]
        public void Verify_WhenClientNotFound_ReturnsFailure()
        {
            var cpf = "123";
            _repoMock.Setup(r => r.GetByCPF(cpf)).Returns((Client)null);

            var result = _service.Verify(cpf);

            Assert.That(result.Success, Is.False);
        }

        [Test]
        public void Verify_WhenScoreInsufficient_ReturnsFailure()
        {
            var cpf = "123";
            var client = new Client();
            _repoMock.Setup(r => r.GetByCPF(cpf)).Returns(client);
            _scoreMock.Setup(s => s.GetScore(cpf)).Returns(500);

            var result = _service.Verify(cpf);

            Assert.That(result.Success, Is.False);
        }

        [Test]
        public void Verify_WhenProofNotFound_ReturnsFailure()
        {
            var cpf = "123";
            var client = new Client();
            _repoMock.Setup(r => r.GetByCPF(cpf)).Returns(client);
            _scoreMock.Setup(s => s.GetScore(cpf)).Returns(700);
            _storageMock.Setup(s => s.FileExists(It.IsAny<string>())).Returns(false);

            var result = _service.Verify(cpf);

            Assert.That(result.Success, Is.False);
        }

        [Test]
        public void Verify_WhenAllValid_ReturnsSuccess()
        {
            var cpf = "123";
            var client = new Client();
            _repoMock.Setup(r => r.GetByCPF(cpf)).Returns(client);
            _scoreMock.Setup(s => s.GetScore(cpf)).Returns(700);
            _storageMock.Setup(s => s.FileExists(It.IsAny<string>())).Returns(true);

            var result = _service.Verify(cpf);
            
            Assert.That("Cliente verificado com sucesso.", Is.EquivalentTo(result.Message));            
            _repoMock.Verify(r => r.Save(client), Times.Once);
        }
    }
}
