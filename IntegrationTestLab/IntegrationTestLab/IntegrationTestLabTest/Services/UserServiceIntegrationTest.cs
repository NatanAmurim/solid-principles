using IntegrationTestLab.Domain.Interfaces;
using IntegrationTestLab.Infra;
using IntegrationTestLab.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace IntegrationTestLabTest.Services
{
    /// <summary>
    /// Aqui fazemos um teste de integração com uma base de dados.
    /// Para que não tenhamos que criar um container num docker e subir uma base, utilizamos o InMemoryDatabase do EF para tal.
    /// </summary>
    public class UserServiceIntegrationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Register_ShouldSaveUserAndSendEmail()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            using var context = new AppDbContext(options);
            var repository = new UserRepository(context);

            var mockNotifier = new Mock<IEmailNotifier>();
            var service = new UserService(repository, mockNotifier.Object);

            service.Register("Test", "test@email.com");

            var savedUser = context.Users.FirstOrDefault(u => u.Email == "test@email.com");
            Assert.IsNotNull(savedUser);

            mockNotifier.Verify(n => n.Send(
                "test@email.com",
                "Bem vindo!",
                "Olá, Test!"), Times.Once);

            Assert.Pass();
        }
    }
}