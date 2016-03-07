using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Analysis.LexicalAnalysis
{
    public interface LexicalAnalyzer
    {
        List<string> Analysis(string expression);
    }
}
