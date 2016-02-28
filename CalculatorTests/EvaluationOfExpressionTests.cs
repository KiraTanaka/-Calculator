using System;
using NUnit.Framework;
using ConsoleCalculator;
using System.Collections;
using System.Collections.Generic;

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
        [Test]
        public void SplitExpressionIntoElementsTest()
        {
            string expression = "(-2)*(3+5.8)+(7-3)";
            List<string> elementsOfExpression = new List<string>();
            List<string> result = new List<string>();

            elementsOfExpression.Add("-2");
            elementsOfExpression.Add("*");
            elementsOfExpression.Add("(");
            elementsOfExpression.Add("3");
            elementsOfExpression.Add("+");
            elementsOfExpression.Add("5.8");
            elementsOfExpression.Add(")");
            elementsOfExpression.Add("+");
            elementsOfExpression.Add("(");
            elementsOfExpression.Add("7");
            elementsOfExpression.Add("-");
            elementsOfExpression.Add("3");
            elementsOfExpression.Add(")");           
           
            result = EvaluationOfExpression.SplitExpressionIntoElements(expression);

            Assert.AreEqual(elementsOfExpression.Count, result.Count);

            for (int i = 0; i < elementsOfExpression.Count; i++)
            {
                Assert.AreEqual(elementsOfExpression[i], result[i]);
            }
        }
        [Test]
        public void CalculationOfSubexpressionTest()
        {
            string expression = "-2*3+-5.8/2";
            List<string> elementsOfSubexpression = new List<string>();

            elementsOfSubexpression.Add("-2");
            elementsOfSubexpression.Add("*");
            elementsOfSubexpression.Add("3");
            elementsOfSubexpression.Add("+");
            elementsOfSubexpression.Add("-5.8");
            elementsOfSubexpression.Add("/");
            elementsOfSubexpression.Add("2");

            Assert.AreEqual("-8.9", EvaluationOfExpression.CalculationOfSubexpression(elementsOfSubexpression));
        }
    }
}
