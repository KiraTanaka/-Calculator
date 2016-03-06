using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.SyntacticAnalysis;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class SyntacticAnalyzerExpressionTests
    {
        [Test]
        public void AnalysisWithCorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression();
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

            Assert.IsTrue(analyzer.Analysis(tokensExpression));
        }

        [Test]
        public void AnalysisWithIncorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression();
            List<string> tokensExpression = new List<string>();

            tokensExpression.Add("*");
            tokensExpression.Add("-2");
            tokensExpression.Add("*");
            tokensExpression.Add("(");
            tokensExpression.Add("3");
            tokensExpression.Add("+");
            tokensExpression.Add("-5.8");
            tokensExpression.Add("/");
            tokensExpression.Add(")");
            tokensExpression.Add(")");
            tokensExpression.Add("*");
            tokensExpression.Add("9");
            tokensExpression.Add("+");
            tokensExpression.Add("(");
            tokensExpression.Add("7");
            tokensExpression.Add("-");
            tokensExpression.Add("*");
            tokensExpression.Add("3");
            tokensExpression.Add(")");

            Assert.IsFalse(analyzer.Analysis(tokensExpression));
        }
    }
}
