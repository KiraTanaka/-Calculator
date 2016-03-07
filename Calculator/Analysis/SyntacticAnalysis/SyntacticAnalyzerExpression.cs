using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.UserInterfaces;
using ConsoleCalculator.DistributorsTokens;

namespace ConsoleCalculator.Analysis.SyntacticAnalysis
{
    public class SyntacticAnalyzerExpression : SyntacticAnalyzer
    {
        UserInterface UserInterface;
        DistributorOfNextTokens DistributorOfNextTokens;

        public SyntacticAnalyzerExpression(UserInterface userInterface, DistributorOfNextTokens distributors)
        {
            this.UserInterface = userInterface;
            this.DistributorOfNextTokens = distributors;
        }

        public bool Analysis(List<string> tokensExpression)
        {
            Tokens nextTokens = DistributorOfNextTokens.GetNextToken("^"); //начало строки

            foreach (var token in tokensExpression)
            {
                if (!nextTokens.ListTokens.Contains(token) && 
                    nextTokens.TokenNumber && 
                    token.FirstOrDefault(x => Char.IsNumber(x)) == '\0')
                {
                    UserInterface.DisplaysErrorMessage("Возможно Вы что-то пропустили перед" + token + ".");
                    return false;
                }               

                nextTokens = DistributorOfNextTokens.GetNextToken(token);                
            }
            if (!nextTokens.ListTokens.Contains("$"))
                return false;

            if (!CheckingBrackets(tokensExpression))
                return false;
            return true;
        }

        public bool CheckingBrackets(List<string> tokensExpression)
        {
            int indexLeftBracket, indexRightBracket, counter;
            List<string> CopyTokensExpression=new List<string>();
            CopyTokensExpression.AddRange(tokensExpression);
            //функция удаляет парные скобки, стоящие в правильном порядке, и их содержимое
            //если остались скобки, значит выражение в строке синтаксически неверное
            while ((CopyTokensExpression.IndexOf("(") < CopyTokensExpression.IndexOf(")"))
                    && (CopyTokensExpression.IndexOf("(") >= 0)
                    && (CopyTokensExpression.IndexOf(")") > 0))
            {
                counter = 0;
                indexLeftBracket = -1;
                indexRightBracket = -1;
                foreach (var token in CopyTokensExpression)
                {
                    if (token == "(")
                        indexLeftBracket = counter;
                    if ((indexLeftBracket >= 0) && (token == ")"))
                    {
                        indexRightBracket = counter;
                        CopyTokensExpression.RemoveRange(indexLeftBracket, indexRightBracket - indexLeftBracket + 1);
                        break;
                    }
                    counter++;
                }
            }
            if (CopyTokensExpression.IndexOf("(") == -1 && CopyTokensExpression.IndexOf(")") == -1)
                return true;

            UserInterface.DisplaysErrorMessage("Выражение записано неверно. Проблема со скобками.");            
            return false;
        }
        
    }
}
