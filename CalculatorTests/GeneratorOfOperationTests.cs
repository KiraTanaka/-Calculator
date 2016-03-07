using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.GeneratorOfOperations;

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
            GeneratorOfOperations generator = new GeneratorOfOperations();
            float resultOfAddition = generator.OperationSelection("+").Execute(firstNumber, secondNumber);

            Assert.AreEqual(10.5f,resultOfAddition);
        }

        [Test]
        public void SubtractionTest()
        {
            GeneratorOfOperations generator = new GeneratorOfOperations();
            float resultOfSubtraction = generator.OperationSelection("-").Execute(firstNumber, secondNumber);

            Assert.AreEqual(3.5f, resultOfSubtraction);
        }

        [Test]
        public void MultiplicationTest()
        {
            GeneratorOfOperations generator = new GeneratorOfOperations();
            float resultOfMultiplication = generator.OperationSelection("*").Execute(firstNumber, secondNumber);

            Assert.AreEqual(24.5f, resultOfMultiplication);
        }

        [Test]
        public void DivisionTest()
        {
            GeneratorOfOperations generator = new GeneratorOfOperations();
            float resultOfDivision = generator.OperationSelection("/").Execute(firstNumber, secondNumber);

            Assert.AreEqual(2, resultOfDivision);
        }
    }
}
