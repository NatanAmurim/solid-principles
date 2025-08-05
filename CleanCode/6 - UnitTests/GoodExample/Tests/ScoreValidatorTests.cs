using CleanCode.UnitTests.Common;
using CleanCode.UnitTests.GoodExample.Classes;
using Moq;
using NUnit.Framework;

namespace CleanCode.UnitTests.GoodExample.Tests
{
    [TestFixture]
    public class ScoreValidatorTests
    {
        private Mock<IScoreService> _scoreMock;
        private ScoreValidator _validator;

        [SetUp]
        public void Setup()
        {
            _scoreMock = new Mock<IScoreService>();
            _validator = new ScoreValidator(_scoreMock.Object);
        }

        [Test]
        public void Validate_ScoreAboveThreshold_ReturnsNull()
        {
            var cpf = "123";
            _scoreMock.Setup(s => s.GetScore(cpf)).Returns(700);

            var result = _validator.Validate(cpf);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Validate_ScoreBelowThreshold_ReturnsFailure()
        {
            var cpf = "123";
            _scoreMock.Setup(s => s.GetScore(cpf)).Returns(500);

            var result = _validator.Validate(cpf);

            Assert.That(result, !Is.Null);
            Assert.That(result.Success, Is.False);
            Assert.That("Score insuficiente.", Is.EqualTo(result.Message));
        }
    }
}
