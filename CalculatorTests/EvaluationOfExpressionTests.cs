using System;
using NUnit.Framework;
using ConsoleCalculator;
using System.Collections;
using System.Collections.Generic;
using ConsoleCalculator.Factories;
using ConsoleCalculator.Evaluations;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class EvaluationOfExpressionTests
    {
        [Test]
        public void EvaluationTest()
        {
            EvaluationOfExpression evaluation = new EvaluationOfExpression();
            List<Token> tokensExpression = new List<Token>();


            tokensExpression.Add(new TokenNumber() { Value = "-2" });
            tokensExpression.Add(new TokenOperations() { Value = "*" });
            tokensExpression.Add(new TokenLeftBracket() { Value = "(" });
            tokensExpression.Add(new TokenNumber() { Value = "3" });
            tokensExpression.Add(new TokenOperations() { Value = "+" });
            tokensExpression.Add(new TokenNumber() { Value = "5.8" });
            tokensExpression.Add(new TokenRightBracket() { Value = ")" });
            tokensExpression.Add(new TokenOperations() { Value = "+" });
            tokensExpression.Add(new TokenLeftBracket() { Value = "(" });
            tokensExpression.Add(new TokenNumber() { Value = "7" });
            tokensExpression.Add(new TokenOperations() { Value = "-" });
            tokensExpression.Add(new TokenNumber() { Value = "3" });
            tokensExpression.Add(new TokenRightBracket() { Value = ")" });

            Assert.AreEqual(-13.6f, evaluation.Calculation(tokensExpression).Number);
        }

        [Test]
        public void CalculationOfSubexpressionTest()
        {
            EvaluationOfExpression evaluation = new EvaluationOfExpression();
            List<Token> tokensOfSubexpression = new List<Token>();

            tokensOfSubexpression.Add(new TokenNumber() { Value = "-2" });
            tokensOfSubexpression.Add(new TokenOperations() { Value = "*" });
            tokensOfSubexpression.Add(new TokenNumber() { Value = "3" });
            tokensOfSubexpression.Add(new TokenOperations() { Value = "+" });
            tokensOfSubexpression.Add(new TokenNumber() { Value = "-5.8" });
            tokensOfSubexpression.Add(new TokenOperations() { Value = "/" });
            tokensOfSubexpression.Add(new TokenNumber() { Value = "2" });

            Assert.AreEqual("-8.9", evaluation.CalculationOfSubexpression(tokensOfSubexpression).Value);
        }
    }
}
