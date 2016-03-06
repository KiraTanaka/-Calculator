using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Generator
{
    public class GeneratorOfOperation : Generator
    {
        Operation Operation;
        public Dictionary<string, int> priorities = new Dictionary<string, int>(){  {"*", 1},
                                                                                    {"/", 2}, 
                                                                                    {"+", 3}, 
                                                                                    {"-", 4}};
        public Dictionary<string, int> GetPriorities()
        {
            return priorities;
        }
        public Operation OperationSelection(string sign)
        {
            switch (sign)
            {
                case "*": return new Multiplication();
                case "/": return new Division();
                case "+": return new Addition();
                case "-": return new Subtraction();
            }
            return null;
        }


    }
}
