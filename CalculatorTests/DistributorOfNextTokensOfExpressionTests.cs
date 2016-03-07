using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.DistributorsTokens;
using System.Collections.Generic;

namespace ConsoleCalculatorTests
{
    public class DistributorOfNextTokensOfExpressionTests
    {
        [Test]
        public void GetNextTokenWithOperationTest()
        {
            DistributorOfNextTokensOfExpression distributor = new DistributorOfNextTokensOfExpression(new TokensExpression());
            Tokens tokens = new Tokens() { TokenNumber = true };
            tokens.ListTokens = new List<string>() { "(" };
            Tokens result = distributor.GetNextToken("+");

            Assert.IsTrue(result.TokenNumber);
            Assert.AreEqual(tokens.ListTokens.Count, result.ListTokens.Count);
            Assert.AreEqual(tokens.ListTokens[0], result.ListTokens[0]);
        }

        [Test]
        public void GetNextTokenWithNumberTest()
        {
            DistributorOfNextTokensOfExpression distributor = new DistributorOfNextTokensOfExpression(new TokensExpression());
            Tokens tokens = new Tokens() { TokenNumber = false };
            tokens.ListTokens = new List<string>() { "*", "/", "+", "-", ")", "$" };
            Tokens result = distributor.GetNextToken("8990.756");

            Assert.IsFalse(result.TokenNumber);
            Assert.AreEqual(tokens.ListTokens.Count, result.ListTokens.Count);
            for (int index = 0; index < tokens.ListTokens.Count; index++)
            {
                Assert.AreEqual(tokens.ListTokens[index], result.ListTokens[index]);
            }
        }

        [Test]
        public void GetNextTokenWithLeftBracketsTest()
        {
            DistributorOfNextTokensOfExpression distributor = new DistributorOfNextTokensOfExpression(new TokensExpression());
            Tokens tokens = new Tokens() { TokenNumber = true };
            tokens.ListTokens = new List<string>() { "-", "(" };
            Tokens result = distributor.GetNextToken("(");

            Assert.IsTrue(result.TokenNumber);
            Assert.AreEqual(tokens.ListTokens.Count, result.ListTokens.Count);
            for (int index = 0; index < tokens.ListTokens.Count; index++)
            {
                Assert.AreEqual(tokens.ListTokens[index], result.ListTokens[index]);
            }
        }

        [Test]
        public void GetNextTokenWithRightBracketsTest()
        {
            DistributorOfNextTokensOfExpression distributor = new DistributorOfNextTokensOfExpression(new TokensExpression());
            Tokens tokens = new Tokens() { TokenNumber = false };
            tokens.ListTokens = new List<string>() { "*", "/", "+", "-", ")", "$" };
            Tokens result = distributor.GetNextToken(")");

            Assert.IsFalse(result.TokenNumber);
            Assert.AreEqual(tokens.ListTokens.Count, result.ListTokens.Count);
            for (int index = 0; index < tokens.ListTokens.Count; index++)
            {
                Assert.AreEqual(tokens.ListTokens[index], result.ListTokens[index]);
            }
        }

        [Test]
        public void GetNextTokenWithBeginningOfLineTest()
        {
            DistributorOfNextTokensOfExpression distributor = new DistributorOfNextTokensOfExpression(new TokensExpression());
            Tokens tokens = new Tokens() { TokenNumber = true };
            tokens.ListTokens = new List<string>() { "(" };
            Tokens result = distributor.GetNextToken("^");

            Assert.IsTrue(result.TokenNumber);
            Assert.AreEqual(tokens.ListTokens.Count, result.ListTokens.Count);
            for (int index = 0; index < tokens.ListTokens.Count; index++)
            {
                Assert.AreEqual(tokens.ListTokens[index], result.ListTokens[index]);
            }
        }
    }
}
