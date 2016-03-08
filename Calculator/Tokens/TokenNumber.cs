using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Tokens
{
    public class TokenNumber : Token
    {
        public override string Value { get; set; }
        public override List<string> symbols { get; set; }

        public TokenNumber()
        {
            this.symbols = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "-" };
        }
    }
}
