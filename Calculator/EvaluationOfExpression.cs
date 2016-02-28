using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class EvaluationOfExpression
    {
        public static List<string> SplitExpressionIntoElements(string expression)
        {
            List<string> elementsOfExpression = new List<string>();
            string number = "";
            bool flagWriteNumber = false;
            bool flagWriteNegativeNumber = false;

            foreach (var symbol in expression)
            {
                if (Char.IsNumber(symbol) || symbol == '.')
                {
                    number += symbol;
                    flagWriteNumber = true;
                }
                else if (symbol == '-' && elementsOfExpression.Last() == "(" && number == "")
                    {
                        elementsOfExpression.RemoveAt(elementsOfExpression.Count-1);
                        number += symbol;
                        flagWriteNegativeNumber = true;
                    }
                    else
                    {
                        flagWriteNumber = false;
                        if (number != "")
                        {
                            elementsOfExpression.Add(number);
                            number = "";
                        }
                        if (flagWriteNegativeNumber)
                            flagWriteNegativeNumber = false;
                        else
                            elementsOfExpression.Add(symbol.ToString());
                    
                    }    
                
            }

            return elementsOfExpression;
        }
        public static float Evaluation (string expression)
        {
            float result = 0;
            List<string> elementsOfExpression = SplitExpressionIntoElements(expression);
            int indexLeftBracket, indexRightBracket, counter;

            while (elementsOfExpression.Count!=1)
            {
                indexLeftBracket = 0;
                indexRightBracket = 0;
                counter = 0;
                if (elementsOfExpression.FindIndex(x=>x == "(")>=0 || elementsOfExpression.FindIndex(x=>x == ")")>0)
                {
                    foreach (var element in elementsOfExpression)
                    {
                        if (element == "(")
                            indexLeftBracket = counter;
                        else if (element == ")")
                            {
                                indexRightBracket = counter;
                                CalculationOfSubexpression(elementsOfExpression.GetRange(indexLeftBracket+1,indexRightBracket-indexLeftBracket-1));
                                break;
                            }
                        counter++;
                    }
                }
                else
                    CalculationOfSubexpression(elementsOfExpression);
            }
            float.TryParse(elementsOfExpression.First(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"), out result);

            return result;
        }
    }
}
