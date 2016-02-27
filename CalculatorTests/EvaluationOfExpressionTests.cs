using System;
using NUnit.Framework;
using ConsoleCalculator;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleCalculatorTests
{
    [TestFixture]
    public class EvaluationOfExpressionTests
    {
        [Test]
        public void EvaluationTest()
        {
            string expression = "((-2)*(3+5))+(7-3)";

            Assert.AreEqual(-12, EvaluationOfExpression.Evaluation(expression));
        }
        [Test]
        public void SplitExpressionIntoElementsTest()
        {
            string expression = "(-2)*(3+5.8)+(7-3)";
            Stack<string> elementsOfExpression = new Stack<string>();
            Stack<string> result = new Stack<string>();
            elementsOfExpression.Push(")");
            elementsOfExpression.Push("3");
            elementsOfExpression.Push("-");
            elementsOfExpression.Push("7");
            elementsOfExpression.Push("(");
            elementsOfExpression.Push("+");
            elementsOfExpression.Push(")");
            elementsOfExpression.Push("5.8");
            elementsOfExpression.Push("+");
            elementsOfExpression.Push("3");
            elementsOfExpression.Push("(");
            elementsOfExpression.Push("*");
            elementsOfExpression.Push("-2");
           
            result = EvaluationOfExpression.SplitExpressionIntoElements(expression);
            int count = elementsOfExpression.Count;

            Assert.AreEqual(elementsOfExpression.Count, result.Count);

            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(elementsOfExpression.Pop(), result.Pop());
            }
        }
    }
}
