using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.GeneratorsOfOperations
{
    public interface GeneratorOfOperations
    {
        Dictionary<string, int> GetPriorities();
        Operation OperationSelection(string sign);
    } 
}
