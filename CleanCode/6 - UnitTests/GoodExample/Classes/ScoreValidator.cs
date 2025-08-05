using CleanCode.UnitTests.Common;

namespace CleanCode.UnitTests.GoodExample.Classes
{
    public class ScoreValidator
    {
        private readonly IScoreService _scoreService;

        public ScoreValidator(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public VerificationResult Validate(string cpf)
        {
            var score = _scoreService.GetScore(cpf);
            if (score < 600)
                return VerificationResult.Fail("Score insuficiente.");

            return null;
        }
    }

}
