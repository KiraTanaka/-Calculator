using System;
using NUnit.Framework;
using ConsoleCalculator;
using System.Collections;
using System.Collections.Generic;
using ConsoleCalculator.DistributorsOperations;
using ConsoleCalculator.Evaluations;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class EvaluationOfExpressionTests
    {
        [Test]
        public void EvaluationTest()
        {
            EvaluationOfExpression evaluation = new EvaluationOfExpression(new DistributorOfOperationsOfExpression());
            List<string> tokensExpression = new List<string>();


            tokensExpression.Add("-2");
            tokensExpression.Add("*");
            tokensExpression.Add("(");
            tokensExpression.Add("3");
            tokensExpression.Add("+");
            tokensExpression.Add("5.8");
            tokensExpression.Add(")");
            tokensExpression.Add("+");
            tokensExpression.Add("(");
            tokensExpression.Add("7");
            tokensExpression.Add("-");
            tokensExpression.Add("3");
            tokensExpression.Add(")");

            Assert.AreEqual(-13.6, evaluation.Calculation(tokensExpression).Number);
        }

        [Test]
        public void CalculationOfSubexpressionTest()
        {
            EvaluationOfExpression evaluation = new EvaluationOfExpression(new DistributorOfOperationsOfExpression());
            List<string> tokensOfSubexpression = new List<string>();

            tokensOfSubexpression.Add("-2");
            tokensOfSubexpression.Add("*");
            tokensOfSubexpression.Add("3");
            tokensOfSubexpression.Add("+");
            tokensOfSubexpression.Add("-5.8");
            tokensOfSubexpression.Add("/");
            tokensOfSubexpression.Add("2");

            Assert.AreEqual("-8.9", evaluation.CalculationOfSubexpression(tokensOfSubexpression));
        }
    }
}
