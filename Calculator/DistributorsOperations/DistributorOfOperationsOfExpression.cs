using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.DistributorsOperations
{
    public class DistributorOfOperationsOfExpression : DistributorOperations
    {       
        Dictionary<string, int> Priorities = new Dictionary<string, int>(){ {"*", 1},
                                                                            {"/", 2}, 
                                                                            {"+", 3}, 
                                                                            {"-", 4}};
        Dictionary<string, Operation> Operation = new Dictionary<string, Operation>(){  {"*", new Multiplication()},
                                                                                        {"/", new Division()}, 
                                                                                        {"+", new Addition()}, 
                                                                                        {"-", new Subtraction()}};

        public Dictionary<string, int> GetPriorities()
        {
            return Priorities;
        }

        public Operation OperationSelection(string sign)
        {
            return Operation[sign];
        }


    }
}
