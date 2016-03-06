using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.SyntacticAnalysis
{
    public class SyntacticAnalyzerExpression : SyntacticAnalyzer
    {
        public bool Analysis(List<string> tokensExpression)
        {
            string[] operation = { "-", "+", "*", "/" };
            string[] nextToken = null;

            foreach (var token in tokensExpression)
            {
                if (nextToken != null && !nextToken.Contains(token) && nextToken.FirstOrDefault(x => token.Contains(x) && x != "-") == null)
                {
                    Console.WriteLine("Возможно Вы что-то пропустили перед" + token + ".");
                    return false;
                }

                if (token.FirstOrDefault(x => x >= '0' && x <= '9') != '\0')
                    nextToken = GetNextTokensAfterNumber();
                else if (operation.Contains(token))
                    nextToken = GetNextTokensAfterOperation();
                else if (token == "(")
                    nextToken = GetNextTokensAfterLeftBrackets();
                else if (token == ")")
                    nextToken = GetNextTokenAfterRightBrackets();
            }
            if (!CheckingBrackets(tokensExpression))
                return false;
            return true;
        }
        private bool CheckingBrackets(List<string> tokensExpression)
        {
            int indexLeftBracket, indexRightBracket, counter;

            //функция удаляет парные скобки, стоящие в правильном порядке, из копии исхоодной строки
            //если остались скобки, значит выражение в строке синтаксически неверное
            while ((tokensExpression.IndexOf("(") < tokensExpression.IndexOf(")"))
                    && (tokensExpression.IndexOf("(") >= 0)
                    && (tokensExpression.IndexOf(")") > 0))
            {
                counter = 0;
                indexLeftBracket = -1;
                indexRightBracket = -1;
                foreach (var token in tokensExpression)
                {
                    if (token == "(")
                        indexLeftBracket = counter;
                    if ((indexLeftBracket >= 0) && (token == ")"))
                    {
                        indexRightBracket = counter;
                        tokensExpression.RemoveRange(indexLeftBracket, indexRightBracket-indexLeftBracket+1);
                        break;
                    }
                    counter++;
                }
            }
            if (tokensExpression.IndexOf("(") == -1 && tokensExpression.IndexOf(")") == -1)
                return true;
            else
                Console.WriteLine("Выражение записано неверно. Проблема со скобками. Проверьте, что они стоят в правильном порядке и у каждой есть пара.");

            return false;
        }
        private string[] GetNextTokensAfterNumber()
        {
            string[] nextTokens = new string[] { "-", "+", "/", "*",  ")" };
            return nextTokens;
        }

        private string[] GetNextTokensAfterOperation()
        {
            string[] nextTokens = new string[] { "(", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return nextTokens;
        }

        private string[] GetNextTokensAfterLeftBrackets()
        {
            string[] nextTokens = new string[] { "-", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return nextTokens;
        }

        private string[] GetNextTokenAfterRightBrackets()
        {
            string[] nextToken = new string[] { "-", "+", "/", "*", ")"};
            return nextToken;
        }
    }
}
