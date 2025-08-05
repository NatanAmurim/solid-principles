using CleanCode.UnitTests.Common;

namespace CleanCode.UnitTests.GoodExample.Classes
{
    public class ProofOfAddressValidator
    {
        private readonly IStorageService _storage;

        public ProofOfAddressValidator(IStorageService storage)
        {
            _storage = storage;
        }

        public VerificationResult Validate(string cpf)
        {
            if (!_storage.FileExists($"comprovantes/{cpf}.pdf"))
                return VerificationResult.Fail("Comprovante de residência não encontrado.");

            return null;
        }
    }

}
