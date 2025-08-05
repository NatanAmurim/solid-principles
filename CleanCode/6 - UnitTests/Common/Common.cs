namespace CleanCode.UnitTests.Common
{
    public interface IClientRepository
    {
        Client GetByCPF(string cpf);
        void Save(Client client);
    }

    public interface IScoreService
    {
        int GetScore(string cpf);
    }

    public interface IStorageService
    {
        bool FileExists(string path);
    }

    public class Client
    {
        public bool Verified { get; set; }
    }

    public class VerificationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static VerificationResult Fail(string message) => new() { Success = false, Message = message };
        public static VerificationResult Ok(string message) => new() { Success = true, Message = message };
    }
}
