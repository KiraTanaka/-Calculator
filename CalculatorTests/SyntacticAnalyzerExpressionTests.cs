using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.Analysis.SyntacticAnalysis;
using ConsoleCalculator.DistributorsTokens;
using ConsoleCalculator.UserInterfaces;
using System.Collections;
using System.Collections.Generic;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class SyntacticAnalyzerExpressionTests
    {
        List<Token> CorrectTokensExpression = new List<Token>() {   new TokenNumber() { Value = "-2" },
                                                                    new TokenOperations() { Value = "*" },
                                                                    new TokenLeftBracket() { Value = "(" },
                                                                    new TokenNumber() { Value = "3" },
                                                                    new TokenOperations() { Value = "+" },
                                                                    new TokenNumber() { Value = "5.8" },
                                                                    new TokenRightBracket() { Value = ")" },
                                                                    new TokenOperations() { Value = "+" },
                                                                    new TokenLeftBracket() { Value = "(" },
                                                                    new TokenNumber() { Value = "7" },
                                                                    new TokenOperations() { Value = "-" },
                                                                    new TokenNumber() { Value = "3" },
                                                                    new TokenRightBracket() { Value = ")" }};

        List<Token> IncorrectTokensExpression = new List<Token>() { new TokenOperations() { Value = "*" },
                                                                    new TokenNumber() { Value = "-2" },
                                                                    new TokenOperations() { Value = "*" },
                                                                    new TokenLeftBracket() { Value = "(" },
                                                                    new TokenNumber() { Value = "3" },
                                                                    new TokenOperations() { Value = "+" },
                                                                    new TokenNumber() { Value = "-5.8" },
                                                                    new TokenOperations() { Value = "/" },
                                                                    new TokenRightBracket() { Value = ")" },
                                                                    new TokenRightBracket() { Value = ")" },
                                                                    new TokenOperations() { Value = "+" },
                                                                    new TokenLeftBracket() { Value = "(" },
                                                                    new TokenNumber() { Value = "7" },
                                                                    new TokenOperations() { Value = "-" },
                                                                    new TokenOperations() { Value = "*" },
                                                                    new TokenNumber() { Value = "3" },
                                                                    new TokenRightBracket() { Value = ")" },
                                                                    new TokenRightBracket() { Value = "+" }};

        [Test]
        public void AnalysisWithCorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression());

            Assert.IsTrue(analyzer.Analysis(CorrectTokensExpression));
        }

        [Test]
        public void AnalysisWithIncorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression());


            Assert.IsFalse(analyzer.Analysis(IncorrectTokensExpression));
        }

        [Test]
        public void CheckingBracketsWithCorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression());
            Assert.IsTrue(analyzer.CheckingBrackets(CorrectTokensExpression));
        }

        [Test]
        public void CheckingBracketsWithIncorrectExpressionTest()
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression(
                                                        new UserInterfaceForExpression());

            Assert.IsFalse(analyzer.CheckingBrackets(IncorrectTokensExpression));
        }
    }
}
