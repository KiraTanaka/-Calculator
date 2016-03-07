using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.DistributorsOperations
{
    public interface DistributorOperations
    {
        Dictionary<string, int> GetPriorities();
        Operation OperationSelection(string sign);
    } 
}
