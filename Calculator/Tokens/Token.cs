using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Tokens
{
    public abstract class Token
    {
        public abstract List<string> symbols { get; set; }
        public abstract string Value { get; set; }
    }
}
