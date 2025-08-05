using NUnit.Framework;

namespace CleanCode.UnitTests
{
    public class CalculatorTest
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldAddTwoNumbersAndReturnSum()
        {
            var result = _calculator.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

    }
}
