using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class EvaluationOfExpressionTests
    {
        [Test]
        public void EvaluationTest()
        {
            string expression = "((-2)*(3+5))+(7-3)";

            Assert.AreEqual(-12, EvaluationOfExpression.Evaluation(expression));
        }
    }
}
