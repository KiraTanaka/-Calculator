using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.DistributorsOperations;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class DistributorOfOperationsOfExpressionTests
    {
        private TypeNumber firstNumber = new TypeNumber() { Number = 7f };
        private TypeNumber secondNumber = new TypeNumber() { Number = 3.5f };

        [Test]
        public void AdditionTest()
        {
            DistributorOperations generator = new DistributorOfOperationsOfExpression();
            TypeNumber resultOfAddition = generator.OperationSelection("+").Execute(firstNumber, secondNumber);

            Assert.AreEqual(10.5f,resultOfAddition.Number);
        }

        [Test]
        public void SubtractionTest()
        {
            DistributorOperations generator = new DistributorOfOperationsOfExpression();
            TypeNumber resultOfSubtraction = generator.OperationSelection("-").Execute(firstNumber, secondNumber);

            Assert.AreEqual(3.5f, resultOfSubtraction.Number);
        }

        [Test]
        public void MultiplicationTest()
        {
            DistributorOperations generator = new DistributorOfOperationsOfExpression();
            TypeNumber resultOfMultiplication = generator.OperationSelection("*").Execute(firstNumber, secondNumber);

            Assert.AreEqual(24.5f, resultOfMultiplication.Number);
        }

        [Test]
        public void DivisionTest()
        {
            DistributorOperations generator = new DistributorOfOperationsOfExpression();
            TypeNumber resultOfDivision = generator.OperationSelection("/").Execute(firstNumber, secondNumber);

            Assert.AreEqual(2, resultOfDivision.Number);
        }
    }
}
