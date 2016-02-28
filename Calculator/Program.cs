using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "((-2)*(3+5))+(7-3)";

            EvaluationOfExpression.Evaluation(expression);
        }
    }
}
