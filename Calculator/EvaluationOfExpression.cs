using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    abstract class Evaluation
    {
        public abstract float Evaluation(string expression);
    }
    public class EvaluationOfExpression : Evaluation
    {
        private Generator Component;
        public EvaluationOfExpression(Generator component)
        {
            this.Component = component;
        }
        public List<string> SplitExpressionIntoElements(string expression)
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
                else if (symbol == '-' && elementsOfExpression.Count() != 0 && elementsOfExpression.Last() == "(" && number == "")
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
            if (number!="")
                elementsOfExpression.Add(number);
            return elementsOfExpression;
        }

        public float Evaluation (string expression)
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
                //если есть скобки в выражении, то вычисляем сначала подвыражения в них
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

        public string CalculationOfSubexpression(List<string> elementsOfExpression)
        {
            Dictionary<string, int> priorities = Component.priorities;
            float leftNumber, rightNumber, resultOfOperation = 0;

            foreach (var priority in priorities)
            {
                for (int index = 0; index < elementsOfExpression.Count; index++)
                {
                    if (priorities.ContainsKey(elementsOfExpression[index]) && priorities[elementsOfExpression[index]] == priority.Value)
                    {
                        float.TryParse(elementsOfExpression[index - 1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out leftNumber);
                        float.TryParse(elementsOfExpression[index + 1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out rightNumber);
                        resultOfOperation = Component.ExecuteOperation(elementsOfExpression[index], leftNumber, rightNumber);
                        elementsOfExpression.RemoveRange(index, 2);
                        elementsOfExpression[index - 1] = resultOfOperation.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
            }

            return elementsOfExpression.First();
        }
    }
}
