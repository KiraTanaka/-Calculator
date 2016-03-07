using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.Analysis.SyntacticAnalysis;
using ConsoleCalculator.DistributorsTokens;
using ConsoleCalculator.UserInterfaces;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class SyntacticAnalyzerExpressionTests
    {
        List<string> CorrectTokensExpression = new List<string>() { "-2", "*", "(", "3", "+", "5.8", ")", "+", "(", "7", "-", "3", ")" };
        List<string> IncorrectTokensExpression = new List<string>() { "*", "-2", "*", "(", "3", "+", "-5.8", "/", ")", ")", "+", "(", "7", "-", "*", "3", ")" ,"+" };

        [Test]
        public void AnalysisWithCorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression(),
                                                        new DistributorOfNextTokens(new TokensExpression()));

            Assert.IsTrue(analyzer.Analysis(CorrectTokensExpression));
        }

        [Test]
        public void AnalysisWithIncorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression(),
                                                        new DistributorOfNextTokens(new TokensExpression()));


            Assert.IsFalse(analyzer.Analysis(IncorrectTokensExpression));
        }

        [Test]
        public void CheckingBracketsWithCorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression(),
                                                        new DistributorOfNextTokens(new TokensExpression()));
            Assert.IsTrue(analyzer.CheckingBrackets(CorrectTokensExpression));
        }

        [Test]
        public void CheckingBracketsWithIncorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression(),
                                                        new DistributorOfNextTokens(new TokensExpression()));

            Assert.IsFalse(analyzer.CheckingBrackets(IncorrectTokensExpression));
        }
    }
}
