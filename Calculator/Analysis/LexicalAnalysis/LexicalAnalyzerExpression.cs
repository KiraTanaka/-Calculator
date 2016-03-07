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
        private List<string> tokensExpression = new List<string>();
        UserInterface UserInterface;

        public LexicalAnalyzerExpression(UserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public List<string> Analysis(string expression)
        {            
            string[] limiters = {"-","+","*","/","(",")"};
            string number = "";
            bool flagNegativeNumber = false;

            foreach (var symbol in expression)
            {
                if (Char.IsNumber(symbol) || symbol == '.')
                    number += symbol;
                else if (symbol == '-' && tokensExpression.Count() != 0 && tokensExpression.Last() == "(" && number == "")
                {
                    tokensExpression.RemoveAt(tokensExpression.Count - 1);
                    number += symbol;
                    flagNegativeNumber = true;
                }
                else if (limiters.Contains(symbol.ToString()))
                {
                    if (number != "")
                    {
                        tokensExpression.Add(number);
                        number = "";
                    }
                    if (!flagNegativeNumber)
                        tokensExpression.Add(symbol.ToString());
                    else
                        flagNegativeNumber = false;
                }
                else
                    UserInterface.DisplaysErrorMessage("В выражении лишний символ " + symbol + ".");
            }
            if (number != "")
                tokensExpression.Add(number);

            return tokensExpression;
        }
    }
}
