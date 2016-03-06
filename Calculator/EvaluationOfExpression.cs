using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Generator;

namespace ConsoleCalculator
{
    public interface Evaluation
    {
        float Calculation(string expression);
    }
    public class EvaluationOfExpression : Evaluation
    {
        private GeneratorOfOperation GeneratorOfOperation;
        public EvaluationOfExpression(GeneratorOfOperation component)
        {
            this.GeneratorOfOperation = component;
        }
        public List<string> SplitExpressionIntoElements(string expression)
        {
            List<string> elementsOfExpression = new List<string>();
            
            return elementsOfExpression;
        }

        public float Calculation(string expression)
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
                            if (indexRightBracket - indexLeftBracket > 2)
                                resultCalculaion = CalculationOfSubexpression(elementsOfExpression.GetRange(indexLeftBracket + 1, indexRightBracket - indexLeftBracket - 1));
                            else
                                resultCalculaion = elementsOfExpression[indexLeftBracket + 1];
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
            Dictionary<string, int> prioritiesOperation = GeneratorOfOperation.GetPriorities();
            float leftNumber, rightNumber, resultOfOperation = 0;

            foreach (var priority in prioritiesOperation)
            {
                for (int index = 0; index < elementsOfExpression.Count; index++)
                {
                    if (prioritiesOperation.ContainsKey(elementsOfExpression[index]) && prioritiesOperation[elementsOfExpression[index]] == priority.Value)
                    {
                        float.TryParse(elementsOfExpression[index - 1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out leftNumber);
                        float.TryParse(elementsOfExpression[index + 1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out rightNumber);
                        resultOfOperation = GeneratorOfOperation.OperationSelection(elementsOfExpression[index]).Execute(leftNumber, rightNumber);
                        elementsOfExpression.RemoveRange(index, 2);
                        elementsOfExpression[index - 1] = resultOfOperation.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
            }

            return elementsOfExpression.First();
        }
    }
}
