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
        [Test]
        public void CheckingSignsWithCorrectExpressionTest()
        {
            correctExpression = "(2*(3+5))+(7-3)";

            Assert.IsTrue(ExpressionValidation.CheckingSigns(correctExpression));
        }
        [Test]
        public void CheckingSignsWithIncorrectExpressionTest()
        {
            incorrectExpression = "(*(-2)*(3+(-5)/)*9)+(7-*3)";

            Assert.IsFalse(ExpressionValidation.CheckingSigns(incorrectExpression));
        }
    }
}
