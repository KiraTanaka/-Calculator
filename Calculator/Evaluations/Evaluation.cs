using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Evaluations
{
    public interface Evaluation
    {
        TypeNumber Calculation(List<string> tokensExpression);
    }
}
