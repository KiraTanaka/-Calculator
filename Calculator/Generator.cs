using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public interface Generator
    {
        public Dictionary<string, int> priorities { get; set; }
        float ExecuteOperation(string sign, float leftNumber, float rightNumber);
    }

    public class GeneratorOfOperation : Generator
    {
        Operation Operation;
        public Dictionary<string, int> priorities = new Dictionary<string, int>(){  {"*", 1},
                                                                                    {"/", 2}, 
                                                                                    {"+", 3}, 
                                                                                    {"-", 4}};
        
        public float ExecuteOperation(string sign, float leftNumber, float rightNumber)
        {
            switch (sign)
            {
                case "*": Operation = new Multiplication();
                    break;
                case "/": Operation = new Division();
                    break;
                case "+": Operation = new Addition();
                    break;
                case "-": Operation = new Subtraction();
                    break;
                default: return 0;
            }
            return Operation.Execute(leftNumber, rightNumber);
        }

        
    }
}
