using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public static float Addition(float firstNumber,float secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public static float Subtraction(float firstNumber, float secondNumber)
        {
            return secondNumber - firstNumber;
        }
        public static float Multiplication(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
