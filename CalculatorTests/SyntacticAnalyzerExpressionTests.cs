using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.SyntacticAnalysis;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    class SyntacticAnalyzerExpressionTests
    {
        [Test]
        public void AnalysisWithCorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression();
            string correctExpression = "((-2)*(3+5))+(7-3)";

            Assert.IsTrue(analyzer.Analysis(correctExpression));
        }

        [Test]
        public void AnalysisWithIncorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression();
            string correctExpression = "(*(-2)*(3+(-5)/)*9)+(7-*3)";

            Assert.IsFalse(analyzer.Analysis(correctExpression));
        }
    }
}
