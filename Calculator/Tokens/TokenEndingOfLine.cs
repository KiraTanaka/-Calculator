using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Tokens
{
    public class TokenOfEndOfLine : Token
    {
        public override string Value { get; set; }
        public override List<string> symbols { get; set; }

        public TokenOfEndOfLine()
        {
            this.symbols = new List<string>() { "$" };
        }
    }
}
