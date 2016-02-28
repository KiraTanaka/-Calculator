using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class ExpressionValidationTests
    {
        private string correctExpression = "(2*(3+5))+(7-3)";
        private string incorrectExpression;

        [Test]
        public void CheckingBracketsWithCorrectExpressionTest()
        {
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
            Assert.IsTrue(ExpressionValidation.CheckingSigns(correctExpression));
        }

        [Test]
        public void CheckingSignsWithIncorrectExpressionTest()
        {
            incorrectExpression = "(*(-2)*(3+(-5)/)*9)+(7-*3)";

            Assert.IsFalse(ExpressionValidation.CheckingSigns(incorrectExpression));
        }

        [Test]
        public void CheckingOfNumbersBetweenSignsWithCorrectExpressionTest()
        {
            Assert.IsTrue(ExpressionValidation.CheckingOfNumbersBetweenSigns(correctExpression));
        }

        [Test]
        public void CheckingOfNumbersBetweenSignsWithIncorrectExpressionTest()
        {
            incorrectExpression = "((-2)6*(3+(-5))*9)+9(7.89.5-3)";

            Assert.IsFalse(ExpressionValidation.CheckingOfNumbersBetweenSigns(incorrectExpression));
        }

        [Test]
        public void CheckOnUnnecessarySymbolsCorrectExpressionTest()
        {
            Assert.IsFalse(ExpressionValidation.CheckOnUnnecessarySymbols(correctExpression));
        }

        [Test]
        public void CheckOnUnnecessarySymbolsIncorrectExpressionTest()
        {
            incorrectExpression = "(п(-2ae)6*(3+(кКЕ-5aer))*9)уа+9(7.89.GF5-ae3)!@#$%^&~':;<>,_=\\|№`[]{}";
            Assert.IsTrue(ExpressionValidation.CheckOnUnnecessarySymbols(incorrectExpression));
        }
    
    }
}
