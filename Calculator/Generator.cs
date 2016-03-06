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

    class GeneratorOfOperation : Generator
    {
        public Dictionary<string, int> priorities = new Dictionary<string, int>(){  {"*", 1},
                                                                                    {"/", 2}, 
                                                                                    {"+", 3}, 
                                                                                    {"-", 4}};
        
        public float ExecuteOperation(string sign, float leftNumber, float rightNumber)
        {
            switch (sign)
            {
                case "*": return Multiplication(leftNumber, rightNumber);
                case "/": return Division(leftNumber, rightNumber);
                case "+": return Addition(leftNumber, rightNumber);
                case "-": return Subtraction(leftNumber, rightNumber);
            }
            return 0;
        }

        public float Addition(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public float Subtraction(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public float Multiplication(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public float Division(float firstNumber, float secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}
