using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private float firstNumber = 3;
        private float secondNumber = 4;

        [Test]
        public void Addition()
        {
            float resultOfAddition = Calculator.Addition(firstNumber,secondNumber);

            Assert.AreEqual(7,resultOfAddition);
        }

        [Test]
        public void Subtraction()
        {
            float resultOfSubtraction = Calculator.Subtraction(firstNumber, secondNumber);

            Assert.AreEqual(1, resultOfAddition);
        }

    }
}
