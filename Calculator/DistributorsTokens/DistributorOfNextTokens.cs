using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.DistributorsTokens
{
    public interface DistributorOfNextTokens
    {
        Tokens GetNextToken(string token);
    }
}
