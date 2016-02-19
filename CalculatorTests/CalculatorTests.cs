using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private float firstNumber = 3.5f;
        private float secondNumber = 7f;

        [Test]
        public void Addition()
        {
            float resultOfAddition = Calculator.Addition(firstNumber,secondNumber);

            Assert.AreEqual(9.5f,resultOfAddition);
        }

        [Test]
        public void Subtraction()
        {
            float resultOfSubtraction = Calculator.Subtraction(firstNumber, secondNumber);

            Assert.AreEqual(3.5f, resultOfSubtraction);
        }

        [Test]
        public void Multiplication()
        {
            float resultOfMultiplication = Calculator.Multiplication(firstNumber, secondNumber);

            Assert.AreEqual(24.5f, resultOfMultiplication);
        }
        [Test]
        public void Division()
        {
            float resultOfDivision = Calculator.Division(firstNumber, secondNumber);

            Assert.AreEqual(2, resultOfDivision);
        }
    }
}
