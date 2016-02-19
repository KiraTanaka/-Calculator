using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {

        [Test]
        public void Addition()
        {
            float firstNumber = 3;
            float secondNumber = 4;

            float resultOfAddition = Calculator.Addition(firstNumber,secondNumber);

            Assert.AreEqual(7,resultOfAddition);
        }


    }
}
