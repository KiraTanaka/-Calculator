using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.Generator;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class GeneratorOfOperationTests
    {
        private float firstNumber = 7f;
        private float secondNumber = 3.5f;

        [Test]
        public void AdditionTest()
        {
            GeneratorOfOperation generator = new GeneratorOfOperation();
            float resultOfAddition = generator.OperationSelection("+").Execute(firstNumber, secondNumber);

            Assert.AreEqual(10.5f,resultOfAddition);
        }

        [Test]
        public void SubtractionTest()
        {
            GeneratorOfOperation generator = new GeneratorOfOperation();
            float resultOfSubtraction = generator.OperationSelection("-").Execute(firstNumber, secondNumber);

            Assert.AreEqual(3.5f, resultOfSubtraction);
        }

        [Test]
        public void MultiplicationTest()
        {
            GeneratorOfOperation generator = new GeneratorOfOperation();
            float resultOfMultiplication = generator.OperationSelection("*").Execute(firstNumber, secondNumber);

            Assert.AreEqual(24.5f, resultOfMultiplication);
        }

        [Test]
        public void DivisionTest()
        {
            GeneratorOfOperation generator = new GeneratorOfOperation();
            float resultOfDivision = generator.OperationSelection("/").Execute(firstNumber, secondNumber);

            Assert.AreEqual(2, resultOfDivision);
        }
    }
}
