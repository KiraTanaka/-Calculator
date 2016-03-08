using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.UserInterfaces;
using ConsoleCalculator.DistributorsTokens;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculator.Analysis.SyntacticAnalysis
{
    public class SyntacticAnalyzerExpression : ISyntacticAnalyzer
    {
        IUserInterface UserInterface;

        public SyntacticAnalyzerExpression(IUserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public bool Analysis(List<Token> tokensExpression)
        {
            List<Type> nextTokens = FactoryTokens.GetNextTokenTypes(new TokenBeginningOfLine()); //начало строки
            foreach (var token in tokensExpression)
            {
                if (nextTokens.FirstOrDefault(x => x == token.GetType()) == null)
                {
                    UserInterface.DisplaysErrorMessage("Возможно Вы что-то пропустили перед " + token.Value + ".");
                    return false;
                }

                nextTokens = FactoryTokens.GetNextTokenTypes(token);
            }
            if (nextTokens.FirstOrDefault(x => x == typeof(TokenOfEndOfLine)) == null)
            {
                UserInterface.DisplaysErrorMessage("Последний символ не может быть в конце.");
                return false;
            }

            if (!CheckingBrackets(tokensExpression))
                return false;
            return true;
        }

        public bool CheckingBrackets(List<Token> tokensExpression)
        {
            int indexLeftBracket = 0, indexRightBracket = 1, counter;
            List<Token> CopyTokensExpression = new List<Token>();
            CopyTokensExpression.AddRange(tokensExpression);
            //функция удаляет парные скобки, стоящие в правильном порядке, и их содержимое
            //если остались скобки, значит выражение в строке синтаксически неверное
            while ((indexLeftBracket < indexRightBracket)
                    && (indexLeftBracket >= 0)
                    && (indexRightBracket > 0))
            {
                counter = 0;
                indexLeftBracket = -1;
                indexRightBracket = 0;
                foreach (var token in CopyTokensExpression)
                {
                    if (token.GetType() == typeof(TokenLeftBracket))
                        indexLeftBracket = counter;
                    if ((indexLeftBracket >= 0) && (token.GetType() == typeof(TokenRightBracket)))
                    {
                        indexRightBracket = counter;
                        CopyTokensExpression.RemoveRange(indexLeftBracket, indexRightBracket - indexLeftBracket + 1);
                        break;
                    }
                    counter++;
                }
                indexLeftBracket = CopyTokensExpression.FindIndex(x => x.GetType() == typeof(TokenLeftBracket));
                indexRightBracket = CopyTokensExpression.FindIndex(x => x.GetType() == typeof(TokenRightBracket));
            }
            if (indexLeftBracket == -1 && indexRightBracket == -1)
                return true;

            UserInterface.DisplaysErrorMessage("Выражение записано неверно. Проблема со скобками.");            
            return false;
        }
        
    }
}
