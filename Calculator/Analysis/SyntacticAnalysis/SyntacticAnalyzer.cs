using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculator.Analysis.SyntacticAnalysis
{
    public interface SyntacticAnalyzer
    {
        bool Analysis(List<Token> tokensExpression);
    }
}
