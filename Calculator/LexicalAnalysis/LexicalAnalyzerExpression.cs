using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.LexicalAnalysis
{
    public class LexicalAnalyzerExpression : LexicalAnalyzer
    {
        private List<string> tokensExpression = new List<string>();

        public List<string> Analysis(string expression)
        {            
            string number = "";

            foreach (var symbol in expression)
            {
                if (Char.IsNumber(symbol) || symbol == '.')
                    number += symbol;
                else if (symbol == '-' && tokensExpression.Count() != 0 && tokensExpression.Last() == "(" && number == "")
                {
                    tokensExpression.RemoveAt(tokensExpression.Count - 1);
                    number += symbol;
                }
                else
                {
                    if (number != "")
                    {
                        tokensExpression.Add(number);
                        number = "";
                    }
                    tokensExpression.Add(symbol.ToString());
                }
            }
            if (number != "")
                tokensExpression.Add(number);

            return tokensExpression;
        }
    }
}
