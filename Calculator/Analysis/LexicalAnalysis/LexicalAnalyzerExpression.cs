using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.UserInterfaces;

namespace ConsoleCalculator.Analysis.LexicalAnalysis
{
    public class LexicalAnalyzerExpression : LexicalAnalyzer
    {
        private List<string> TokensExpression = new List<string>();
        UserInterface UserInterface;
        Tokens Tokens;

        public LexicalAnalyzerExpression(UserInterface userInterface, Tokens tokens)
        {
            this.UserInterface = userInterface;
            this.Tokens = tokens;
        }

        public List<string> Analysis(string expression)
        {            
            string number = "";
            bool flagNegativeNumber = false;

            foreach (var symbol in expression)
            {
                if (Char.IsNumber(symbol) || symbol == '.')
                    number += symbol;
                else if (symbol == '-' && TokensExpression.Count() != 0 && TokensExpression.Last() == "(" && number == "")
                {
                    TokensExpression.RemoveAt(TokensExpression.Count - 1);
                    number += symbol;
                    flagNegativeNumber = true;
                }
                else if (Tokens.ListTokens.Contains(symbol.ToString()))
                {
                    if (number != "")
                    {
                        TokensExpression.Add(number);
                        number = "";
                    }
                    if (!flagNegativeNumber)
                        TokensExpression.Add(symbol.ToString());
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
                TokensExpression.Add(number);

            return TokensExpression;
        }
    }
}
