using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Calculation
{
    public interface Evaluation
    {
        float Calculation(List<string> tokensExpression);
    }
}
