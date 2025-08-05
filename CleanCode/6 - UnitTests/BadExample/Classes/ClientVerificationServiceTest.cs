using CleanCode.UnitTests.Common;
using Moq;
using NUnit.Framework;

namespace CleanCode.UnitTests.BadExample.Classes
{
    [TestFixture]
    public class ClientVerificationServiceTests
    {
        private Mock<IClientRepository> _clientRepoMock;
        private Mock<IScoreService> _scoreServiceMock;
        private Mock<IStorageService> _storageServiceMock;

        private ClientVerificationService _service;

        [SetUp]
        public void Setup()
        {
            _clientRepoMock = new Mock<IClientRepository>();
            _scoreServiceMock = new Mock<IScoreService>();
            _storageServiceMock = new Mock<IStorageService>();

            _service = new ClientVerificationService(
                _clientRepoMock.Object,
                _scoreServiceMock.Object,
                _storageServiceMock.Object
            );
        }

        [Test]
        public void Should_Fail_When_Client_Not_Found()
        {
            _clientRepoMock.Setup(r => r.GetByCPF("123")).Returns((Client)null);

            var result = _service.Verify("123");

            Assert.That(result.Success, Is.False);
            Assert.That("Cliente não encontrado.", Is.EqualTo(result.Message));
        }

        [Test]
        public void Should_Fail_When_Score_Is_Too_Low()
        {
            _clientRepoMock.Setup(r => r.GetByCPF("123")).Returns(new Client());
            _scoreServiceMock.Setup(s => s.GetScore("123")).Returns(400);

            var result = _service.Verify("123");

            Assert.That(result.Success, Is.False);
            Assert.That("Score insuficiente.", Is.EqualTo(result.Message));
        }

        [Test]
        public void Should_Fail_When_Proof_Of_Address_Missing()
        {
            _clientRepoMock.Setup(r => r.GetByCPF("123")).Returns(new Client());
            _scoreServiceMock.Setup(s => s.GetScore("123")).Returns(700);
            _storageServiceMock.Setup(s => s.FileExists("comprovantes/123.pdf")).Returns(false);

            var result = _service.Verify("123");

            Assert.That(result.Success, Is.False);
            Assert.That("Comprovante de residência não encontrado.", Is.EqualTo(result.Message));
        }

        [Test]
        public void Should_Succeed_When_All_Validations_Pass()
        {
            var client = new Client();

            _clientRepoMock.Setup(r => r.GetByCPF("123")).Returns(client);
            _scoreServiceMock.Setup(s => s.GetScore("123")).Returns(750);
            _storageServiceMock.Setup(s => s.FileExists("comprovantes/123.pdf")).Returns(true);

            var result = _service.Verify("123");

            Assert.That(result.Success, Is.True);
            Assert.That("Cliente verificado com sucesso.", Is.EqualTo(result.Message));
            Assert.That(client.Verified, Is.True);
            _clientRepoMock.Verify(r => r.Save(client), Times.Once);
        }
    }
}
