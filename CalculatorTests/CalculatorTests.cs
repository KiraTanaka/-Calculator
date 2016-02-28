using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private float firstNumber = 3.5f;
        private float secondNumber = 7f;

        [Test]
        public void AdditionTest()
        {
            float resultOfAddition = Calculator.Addition(firstNumber,secondNumber);

            Assert.AreEqual(10.5f,resultOfAddition);
        }

        [Test]
        public void SubtractionTest()
        {
            float resultOfSubtraction = Calculator.Subtraction(secondNumber, firstNumber);

            Assert.AreEqual(3.5f, resultOfSubtraction);
        }

        [Test]
        public void MultiplicationTest()
        {
            float resultOfMultiplication = Calculator.Multiplication(firstNumber, secondNumber);

            Assert.AreEqual(24.5f, resultOfMultiplication);
        }

        [Test]
        public void DivisionTest()
        {
            float resultOfDivision = Calculator.Division(secondNumber, firstNumber);

            Assert.AreEqual(2, resultOfDivision);
        }
    }
}
