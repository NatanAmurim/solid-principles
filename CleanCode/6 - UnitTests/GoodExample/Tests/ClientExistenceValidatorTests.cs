using CleanCode.UnitTests.Common;
using CleanCode.UnitTests.GoodExample.Classes;
using Moq;
using NUnit.Framework;

namespace CleanCode.UnitTests.GoodExample.Tests
{        
    [TestFixture]
    public class ClientExistenceValidatorTests
    {
        private Mock<IClientRepository> _repoMock;
        private ClientExistenceValidator _validator;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IClientRepository>();
            _validator = new ClientExistenceValidator(_repoMock.Object);
        }

        [Test]
        public void Validate_ClientExists_ReturnsValid()
        {
            var cpf = "12345678900";
            var client = new Client();
            _repoMock.Setup(r => r.GetByCPF(cpf)).Returns(client);

            var (isValid, returnedClient, result) = _validator.Validate(cpf);

            Assert.That(isValid);
            Assert.That(client, Is.EqualTo(returnedClient));
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Validate_ClientDoesNotExist_ReturnsInvalid()
        {
            var cpf = "12345678900";
            _repoMock.Setup(r => r.GetByCPF(cpf)).Returns((Client)null);

            var (isValid, returnedClient, result) = _validator.Validate(cpf);

            Assert.That(isValid, Is.False);
            Assert.That(returnedClient, Is.Null);
            Assert.That(result, !Is.Null);
            Assert.That(result.Success, Is.False);
            Assert.That("Cliente não encontrado.", Is.EqualTo(result.Message));
        }
    }
}
