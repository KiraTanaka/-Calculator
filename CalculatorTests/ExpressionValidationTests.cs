using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class ExpressionValidationTests
    {
        [Test]
        public void CheckingBracketsTest()
        {
            float resultOfAddition = Calculator.Addition(firstNumber, secondNumber);

            Assert.AreEqual(10.5f, resultOfAddition);
        }
    }
}
