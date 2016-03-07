using System;
using NUnit.Framework;
using ConsoleCalculator;
using System.Collections;
using System.Collections.Generic;
using ConsoleCalculator.GeneratorOfOperations;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class EvaluationOfExpressionTests
    {
        [Test]
        public void EvaluationTest()
        {
            EvaluationOfExpression evaluation = new EvaluationOfExpression(new GeneratorOfOperations());
            string expression = "((-2)*(3+5))+(7-3)";

            Assert.AreEqual(-12, evaluation.Calculation(expression));
        }
        [Test]
        public void CalculationOfSubexpressionTest()
        {
            EvaluationOfExpression evaluation = new EvaluationOfExpression(new GeneratorOfOperations());
            List<string> elementsOfSubexpression = new List<string>();

            elementsOfSubexpression.Add("-2");
            elementsOfSubexpression.Add("*");
            elementsOfSubexpression.Add("3");
            elementsOfSubexpression.Add("+");
            elementsOfSubexpression.Add("-5.8");
            elementsOfSubexpression.Add("/");
            elementsOfSubexpression.Add("2");

            Assert.AreEqual("-8.9", evaluation.CalculationOfSubexpression(elementsOfSubexpression));
        }
    }
}
