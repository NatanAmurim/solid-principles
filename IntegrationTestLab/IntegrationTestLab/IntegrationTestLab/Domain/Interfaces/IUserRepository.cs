namespace IntegrationTestLab.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
        User GetByEmail(string email);
    }
}
