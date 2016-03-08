using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.UserInterfaces;
using ConsoleCalculator.Tokens;
using ConsoleCalculator.DistributorsTokens;

namespace ConsoleCalculator.Analysis.LexicalAnalysis
{
    public class LexicalAnalyzerExpression : LexicalAnalyzer
    {
        private List<Token> TokensExpression = new List<Token>();
        UserInterface UserInterface;

        public LexicalAnalyzerExpression(UserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public List<Token> Analysis(string expression)
        {            
            Token token;
            string number = "";
            bool flagNegativeNumber = false;

            foreach (var symbol in expression)
            {
                if (Char.IsNumber(symbol) || symbol == '.')
                    number += symbol;
                else if (symbol == '-' && TokensExpression.Count() != 0 && TokensExpression.Last().Value == "(" && number == "")
                {
                    TokensExpression.RemoveAt(TokensExpression.Count - 1);
                    number += symbol;
                    flagNegativeNumber = true;
                }
                else if ((token = DistributorOfNextTokens.GetToken(symbol.ToString())) != null)
                {
                    if (number != "")
                    {
                        TokensExpression.Add(new TokenNumber() { Value = number});
                        number = "";
                    }
                    if (!flagNegativeNumber)
                        TokensExpression.Add(token);
                    else
                        flagNegativeNumber = false;
                }
                else
                {
                    UserInterface.DisplaysErrorMessage("В выражении лишний символ " + symbol + ".");
                    return null;
                }
            }
            if (number != "")
                TokensExpression.Add(new TokenNumber() { Value = number});

            return TokensExpression;
        }
    }
}
