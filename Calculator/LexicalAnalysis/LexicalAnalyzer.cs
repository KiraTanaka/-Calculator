using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.LexicalAnalysis
{
    public interface LexicalAnalyzer
    {
        public List<string> Analysis(string expression);
    }
}
