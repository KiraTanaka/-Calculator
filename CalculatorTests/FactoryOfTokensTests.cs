using System;
using NUnit.Framework;
using ConsoleCalculator;
using ConsoleCalculator.DistributorsTokens;
using System.Collections.Generic;
using ConsoleCalculator.Tokens;
using ConsoleCalculator.Factories;

namespace ConsoleCalculatorTests
{
    public class FactoryOfTokensTests
    {
        [Test]
        public void GetNextTokenTypesWithOperationTest()
        {
            List<Type> nextTokenTypes = new List<Type>();
            nextTokenTypes.Add(typeof(TokenLeftBracket));
            nextTokenTypes.Add(typeof(TokenNumber));

            List<Type> result = FactoryOfTokens.GetNextTokenTypes(new TokenOperations());

            Assert.AreEqual(nextTokenTypes.Count, result.Count);
            for (int index = 0; index < nextTokenTypes.Count; index++)
            {
                Assert.AreEqual(nextTokenTypes[0], result[0]);
            }
        }

        [Test]
        public void GetNextTokenTypesWithNumberTest()
        {
            List<Type> nextTokenTypes = new List<Type>();
            nextTokenTypes.Add(typeof(TokenOperations));
            nextTokenTypes.Add(typeof(TokenRightBracket));
            nextTokenTypes.Add(typeof(TokenOfEndOfLine));

            List<Type> result = FactoryOfTokens.GetNextTokenTypes(new TokenNumber());

            Assert.AreEqual(nextTokenTypes.Count, result.Count);
            for (int index = 0; index < nextTokenTypes.Count; index++)
            {
                Assert.AreEqual(nextTokenTypes[index], result[index]);
            }
        }

        [Test]
        public void GetNextTokenTypesWithLeftBracketsTest()
        {
            List<Type> nextTokenTypes = new List<Type>();
            nextTokenTypes.Add(typeof(TokenLeftBracket));
            nextTokenTypes.Add(typeof(TokenNumber));

            List<Type> result = FactoryOfTokens.GetNextTokenTypes(new TokenLeftBracket());

            Assert.AreEqual(nextTokenTypes.Count, result.Count);
            for (int index = 0; index < nextTokenTypes.Count; index++)
            {
                Assert.AreEqual(nextTokenTypes[index], result[index]);
            }
        }

        [Test]
        public void GetNextTokenTypesWithRightBracketsTest()
        {
            List<Type> nextTokenTypes = new List<Type>();
            nextTokenTypes.Add(typeof(TokenOperations));
            nextTokenTypes.Add(typeof(TokenRightBracket));
            nextTokenTypes.Add(typeof(TokenOfEndOfLine));

            List<Type> result = FactoryOfTokens.GetNextTokenTypes(new TokenRightBracket());

            Assert.AreEqual(nextTokenTypes.Count, result.Count);
            for (int index = 0; index < nextTokenTypes.Count; index++)
            {
                Assert.AreEqual(nextTokenTypes[index], result[index]);
            }
        }

        [Test]
        public void GetNextTokenTypesWithBeginningOfLineTest()
        {
            List<Type> nextTokenTypes = new List<Type>();
            nextTokenTypes.Add(typeof(TokenNumber));
            nextTokenTypes.Add(typeof(TokenLeftBracket));

            List<Type> result = FactoryOfTokens.GetNextTokenTypes(new TokenBeginningOfLine());

            Assert.AreEqual(nextTokenTypes.Count, result.Count);
            for (int index = 0; index < nextTokenTypes.Count; index++)
            {
                Assert.AreEqual(nextTokenTypes[index], result[index]);
            }
        }
    }
}
