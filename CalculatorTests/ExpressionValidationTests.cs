using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class ExpressionValidationTests
    {
        private string correctExpression;
        private string incorrectExpression;
        [Test]
        public void CheckingBracketsWithCorrectExpressionTest()
        {
            correctExpression = "(2*(3+5))+(7-3)";

            Assert.IsTrue(ExpressionValidation.CheckingBrackets(correctExpression));
        }
        [Test]
        public void CheckingBracketsWithIncorrectExpressionTest()
        {
            incorrectExpression = "2*)(3+5)+(7-3))";

            Assert.IsFalse(ExpressionValidation.CheckingBrackets(incorrectExpression));
        }
    }
}
