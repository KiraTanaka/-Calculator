using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Tokens
{
    public class TokenOperations : Token
    {
        public override string Value { get; set; }
        public override List<string> symbols { get; set; }

        public TokenOperations()
        {
            this.symbols = new List<string>() { "+", "-", "*","/" };
        }
    }
}
