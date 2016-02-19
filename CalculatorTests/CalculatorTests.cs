using System;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {

        [Test]
        public void AdditionTest()
        {
            var calculator = new Calculator();
            float firstNumber = 3;
            float secondNumber = 4;

            int resultOfAddition = calculator.Addition(firstNumber,secondNumber);

            Assert.AreEqual(7,resultOfAddition);
        }

    }
}
