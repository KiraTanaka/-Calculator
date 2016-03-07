using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.GeneratorsOfOperations;

namespace ConsoleCalculator.Calculation
{
    public class EvaluationOfExpression : Evaluation
    {
        private GeneratorOfOperations GeneratorOfOperation;

        public EvaluationOfExpression(GeneratorOfOperations component)
        {
            this.GeneratorOfOperation = component;
        }

        public float Calculation(List<string> tokensExpression)
        {
            float result = 0;
            int indexLeftBracket, indexRightBracket, counter;
            string resultCalculaion = "";

            while (tokensExpression.Count != 1)
            {
                indexLeftBracket = 0;
                indexRightBracket = 0;
                counter = 0;
                //если есть скобки в выражении, то вычисляем сначала подвыражения в них
                if (tokensExpression.FindIndex(x => x == "(") >= 0 || tokensExpression.FindIndex(x => x == ")") > 0)
                {
                    foreach (var element in tokensExpression)
                    {
                        if (element == "(")
                            indexLeftBracket = counter;
                        else if (element == ")")
                        {
                            indexRightBracket = counter;
                            if (indexRightBracket - indexLeftBracket > 2)
                                resultCalculaion = CalculationOfSubexpression(tokensExpression.GetRange(indexLeftBracket + 1, indexRightBracket - indexLeftBracket - 1));
                            else
                                resultCalculaion = tokensExpression[indexLeftBracket + 1];
                            tokensExpression.RemoveRange(indexLeftBracket + 1, indexRightBracket - indexLeftBracket);
                            tokensExpression[indexLeftBracket] = resultCalculaion;
                            break;
                        }
                        counter++;
                    }
                }
                else
                    resultCalculaion = CalculationOfSubexpression(tokensExpression);
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
