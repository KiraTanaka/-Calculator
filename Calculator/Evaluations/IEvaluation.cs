using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculator.Evaluations
{
    public interface IEvaluation
    {
        TypeNumber Calculation(List<Token> tokensExpression);
    }
}
