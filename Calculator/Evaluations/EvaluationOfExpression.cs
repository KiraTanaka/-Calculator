using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.DistributorsOperations;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculator.Evaluations
{
    public class EvaluationOfExpression : Evaluation
    {
        private DistributorOperations GeneratorOfOperations;

        public EvaluationOfExpression(DistributorOperations component)
        {
            this.GeneratorOfOperations = component;
        }

        public TypeNumber Calculation(List<Token> tokensExpression)
        {
            TypeNumber result = new TypeNumber();
            int indexLeftBracket, indexRightBracket, counter;
            Token resultCalculaion = null;

            while (tokensExpression.Count != 1)
            {
                indexLeftBracket = 0;
                indexRightBracket = 0;
                counter = 0;

                //если есть скобки в выражении, то вычисляем сначала подвыражения в них
                if (tokensExpression.FindIndex(x => x.GetType() == typeof(TokenLeftBracket) || x.GetType() == typeof(TokenRightBracket)) >= 0 )
                {
                    foreach (var element in tokensExpression)
                    {
                        if (element.GetType() == typeof(TokenLeftBracket))
                            indexLeftBracket = counter;
                        else if (element.GetType() == typeof(TokenRightBracket))
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
            
            result.Number = TypeNumber.TryParse(resultCalculaion.Value);

            return result;
        }

        public Token CalculationOfSubexpression(List<Token> tokensSubexpression)
        {
            Dictionary<string, int> prioritiesOperation = GeneratorOfOperations.GetPriorities();
            TypeNumber leftNumber = new TypeNumber(), rightNumber = new TypeNumber(), resultOfOperation = new TypeNumber();
            Operation operation = null;

            foreach (var priority in prioritiesOperation.Values)
            {
                for (int index = 0; index < tokensSubexpression.Count; index++)
                {
                    if (prioritiesOperation.FirstOrDefault(x => x.Key == tokensSubexpression[index].Value).Value == priority)
                    {
                        leftNumber.Number = TypeNumber.TryParse(tokensSubexpression[index - 1].Value);
                        rightNumber.Number = TypeNumber.TryParse(tokensSubexpression[index + 1].Value);
                        operation = GeneratorOfOperations.OperationSelection(tokensSubexpression[index].Value);
                        resultOfOperation = operation.Execute(leftNumber, rightNumber);
                        tokensSubexpression.RemoveRange(index, 2);
                        tokensSubexpression[index - 1].Value = resultOfOperation.NumberToString();
                    }
                }
            }

            return tokensSubexpression.First();
        }
    }
}
