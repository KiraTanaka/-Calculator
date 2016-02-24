using System;
using NUnit.Framework;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class ParserExpressionTests
    {
        [Test]
        public void ParsingTest()
        {
            string expression = "((-2)*(3+5))+(7-3)";

            Assert.AreEqual(-12,ParserExpression.Parsing(expression));
        }
    }
}
