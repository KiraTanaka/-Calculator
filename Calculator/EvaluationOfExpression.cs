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
            string resultCalculaion = "";

            while (elementsOfExpression.Count!=1)
            {
                indexLeftBracket = 0;
                indexRightBracket = 0;
                counter = 0;
                if (elementsOfExpression.FindIndex(x => x == "(") >= 0 || elementsOfExpression.FindIndex(x => x == ")") > 0)
                {
                    foreach (var element in elementsOfExpression)
                    {
                        if (element == "(")
                            indexLeftBracket = counter;
                        else if (element == ")")
                        {
                            indexRightBracket = counter;
                            resultCalculaion = CalculationOfSubexpression(elementsOfExpression.GetRange(indexLeftBracket + 1, indexRightBracket - indexLeftBracket - 1));
                            elementsOfExpression.RemoveRange(indexLeftBracket + 1, indexRightBracket - indexLeftBracket);
                            elementsOfExpression[indexLeftBracket] = resultCalculaion;
                            break;
                        }
                        counter++;
                    }
                }
                else
                    resultCalculaion = CalculationOfSubexpression(elementsOfExpression);
            }
            float.TryParse(resultCalculaion, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result);

            return result;
        }

        public static string CalculationOfSubexpression(List<string> elementsOfExpression)
        {
            Dictionary<string, int> priorities = new Dictionary<string, int>(){ {"*", 1},
                                                                                {"/", 2}, 
                                                                                {"+", 3}, 
                                                                                {"-", 4}};
            float leftNumber, rightNumber, resultOfOperation = 0;

            for (int priorityOperation = 1; priorityOperation <= priorities.Count; priorityOperation++)
			{	
                for (int i = 0; i < elementsOfExpression.Count; i++)
                {
                    if (priorities.ContainsKey(elementsOfExpression[i]) && priorities[elementsOfExpression[i]] == priorityOperation)
                    {
                        float.TryParse(elementsOfExpression[i - 1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out leftNumber);
                        float.TryParse(elementsOfExpression[i + 1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out rightNumber);
                        switch (priorityOperation)
                        {
                            case 1: resultOfOperation = Calculator.Multiplication(leftNumber, rightNumber);
                                break;
                            case 2: resultOfOperation = Calculator.Division(leftNumber, rightNumber); 
                                break;
                            case 3: resultOfOperation = Calculator.Addition(leftNumber, rightNumber); 
                                break;
                            case 4: resultOfOperation = Calculator.Subtraction(leftNumber, rightNumber); 
                                break;
                        }
                        elementsOfExpression.RemoveRange(i,2);
                        elementsOfExpression[i - 1] = resultOfOperation.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
            }

            return elementsOfExpression.First();
        }
    }
}
