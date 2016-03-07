using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.Analysis.LexicalAnalysis;
using ConsoleCalculator.UserInterfaces;
using System.Collections;
using System.Collections.Generic;

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
            List<string> tokensExpression = new List<string>();
            List<string> result = new List<string>();

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

            result = analyzer.Analysis(expression);

            Assert.AreEqual(tokensExpression.Count, result.Count);

            for (int i = 0; i < tokensExpression.Count; i++)
            {
                Assert.AreEqual(tokensExpression[i], result[i]);
            }
        }
    }
}
