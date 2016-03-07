using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.DistributorsTokens
{
    public class TokensExpression : Tokens
    {
        public TokensExpression()
        {
            TokenNumber = true;
            ListTokens = new List<string>();
            ListTokens.Add("*");
            ListTokens.Add("/");
            ListTokens.Add("+");
            ListTokens.Add("-");
            ListTokens.Add("(");
            ListTokens.Add(")");
        }

        
    }
}
