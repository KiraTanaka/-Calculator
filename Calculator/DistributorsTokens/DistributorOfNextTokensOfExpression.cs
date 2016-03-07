using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.DistributorsTokens
{
    public class DistributorOfNextTokensOfExpression : DistributorOfNextTokens
    {
        Tokens Tokens;

        public DistributorOfNextTokensOfExpression(Tokens tokens)
        {
            this.Tokens = tokens;
        }

        public Tokens GetNextToken(string token)
        {
            Tokens nextTokens = new Tokens();
            if (token.FirstOrDefault(x => x >= '0' && x <= '9') != '\0')
                GetNextTokensAfterNumber(ref nextTokens);
            else if (Tokens.ListTokens.GetRange(0,4).Contains(token)) //operation
                GetNextTokensAfterOperation(ref nextTokens);
            else if (token == Tokens.ListTokens[4]) //"("
                GetNextTokensAfterLeftBrackets(ref nextTokens);
            else if (token == Tokens.ListTokens[5]) //")"
                GetNextTokensAfterRightBrackets(ref nextTokens);
            else if (token == "^")
                GetNextTokensAfterBeginningOfLine(ref nextTokens);//начало строки
            return nextTokens;
        }

        private void GetNextTokensAfterNumber(ref Tokens nextTokens)
        {
            nextTokens.ListTokens = new List<string>();
            for (int index = 0; index < Tokens.ListTokens.Count - 2; index++) // "*", "/", "+", "-"
			{
                nextTokens.ListTokens.Add(Tokens.ListTokens[index]); 
			}
            nextTokens.ListTokens.Add(Tokens.ListTokens[5]); //")"
            nextTokens.ListTokens.Add("$"); //конец строки
            nextTokens.TokenNumber = false;
        }

        private void GetNextTokensAfterOperation(ref Tokens nextTokens)
        {
            nextTokens.TokenNumber = true;
            nextTokens.ListTokens = new List<string>();
            nextTokens.ListTokens.Add(Tokens.ListTokens[4]);//"("
        }

        private void GetNextTokensAfterLeftBrackets(ref Tokens nextTokens)
        {
            nextTokens.TokenNumber = true;
            nextTokens.ListTokens = new List<string>();
            nextTokens.ListTokens.Add(Tokens.ListTokens[3]);//"-"
            nextTokens.ListTokens.Add(Tokens.ListTokens[4]);//"("
        }

        private void GetNextTokensAfterRightBrackets(ref Tokens nextTokens)
        {
            nextTokens.ListTokens = new List<string>();
            for (int index = 0; index < Tokens.ListTokens.Count - 2; index++) // "*", "/", "+", "-"
            {
                nextTokens.ListTokens.Add(Tokens.ListTokens[index]); 
            }
            nextTokens.ListTokens.Add(Tokens.ListTokens[5]); // ")" 
            nextTokens.ListTokens.Add("$"); //конец строки
        }
        private void GetNextTokensAfterBeginningOfLine(ref Tokens nextTokens)
        {
            nextTokens.TokenNumber = true;
            nextTokens.ListTokens = new List<string>();
            nextTokens.ListTokens.Add(Tokens.ListTokens[4]); // "(" 
        }
    }
}
