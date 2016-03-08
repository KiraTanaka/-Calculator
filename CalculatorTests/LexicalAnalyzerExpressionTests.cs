using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.Analysis.LexicalAnalysis;
using ConsoleCalculator.UserInterfaces;
using System.Collections;
using System.Collections.Generic;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class LexicalAnalyzerExpressionTests
    {
        [Test]
        public void AnalysisTest()
        {
            LexicalAnalyzerExpression analyzer = new LexicalAnalyzerExpression(new UserInterfaceForExpression());
            string expression = "(-2)*(3+5.8)+(7-3)";
            List<Token> tokensExpression = new List<Token>();
            List<Token> result = new List<Token>();

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

            result = analyzer.Analysis(expression);

            Assert.AreEqual(tokensExpression.Count, result.Count);

            for (int i = 0; i < tokensExpression.Count; i++)
            {
                Assert.AreEqual(tokensExpression[i].GetType(), result[i].GetType());
                Assert.AreEqual(tokensExpression[i].Value, result[i].Value);
            }
        }
    }
}
