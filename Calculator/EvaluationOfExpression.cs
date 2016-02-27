using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class EvaluationOfExpression
    {
        public static Stack<string> SplitExpressionIntoElements(string expression)
        {
            Stack<string> elementsOfExpression = new Stack<string>();
            Stack<string> invertedStackElementsOfExpression = new Stack<string>();
            string number = "";//(-9)
            bool flagWriteNumber=false;
            bool flagWriteNegativeNumber = false;
            int countOfElementsInStack = 0;

            foreach (var symbol in expression)
            {
                if (Char.IsNumber(symbol) || symbol == '.')
                {
                    number += symbol;
                    flagWriteNumber = true;
                }
                else if (symbol == '-' && elementsOfExpression.Peek() == "(" && number == "")
                    {
                        elementsOfExpression.Pop();
                        number += symbol;
                        flagWriteNegativeNumber = true;
                    }
                    else
                    {
                        flagWriteNumber = false;
                        if (number != "")
                        {
                            elementsOfExpression.Push(number);
                            number = "";
                        }
                        if (flagWriteNegativeNumber)
                            flagWriteNegativeNumber = false;
                        else
                            elementsOfExpression.Push(symbol.ToString());
                    
                    }    
                
            }
            countOfElementsInStack = elementsOfExpression.Count;
            for (int i = 0; i < countOfElementsInStack; i++)
            {
                invertedStackElementsOfExpression.Push(elementsOfExpression.Pop());
            }
            return invertedStackElementsOfExpression;
        }
        public static float Evaluation (string expression)
        {
            float result = 0;//((-2)*(3+5))+(7-3)
            


            return result;
        }
    }
}
