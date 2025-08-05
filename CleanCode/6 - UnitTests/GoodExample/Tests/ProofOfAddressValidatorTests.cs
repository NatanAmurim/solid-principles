using CleanCode.UnitTests.Common;
using CleanCode.UnitTests.GoodExample.Classes;
using Moq;
using NUnit.Framework;

namespace CleanCode.UnitTests.GoodExample.Tests
{
    [TestFixture]
    public class ProofOfAddressValidatorTests
    {
        private Mock<IStorageService> _storageMock;
        private ProofOfAddressValidator _validator;

        [SetUp]
        public void Setup()
        {
            _storageMock = new Mock<IStorageService>();
            _validator = new ProofOfAddressValidator(_storageMock.Object);
        }

        [Test]
        public void Validate_FileExists_ReturnsNull()
        {
            var cpf = "123";
            _storageMock.Setup(s => s.FileExists($"comprovantes/{cpf}.pdf")).Returns(true);

            var result = _validator.Validate(cpf);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Validate_FileDoesNotExist_ReturnsFailure()
        {
            var cpf = "123";
            _storageMock.Setup(s => s.FileExists($"comprovantes/{cpf}.pdf")).Returns(false);

            var result = _validator.Validate(cpf);

            Assert.That(result, !Is.Null);
            Assert.That(result.Success, Is.False);
            Assert.That("Comprovante de residência não encontrado.", Is.EqualTo(result.Message));
        }
    }
}
