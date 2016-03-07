using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public interface Operation
    {
        float Execute(float firstNumber, float secondNumber);
    }
    class Addition : Operation
    {
        public float Execute(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
    class Subtraction : Operation
    {
        public float Execute(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
    class Multiplication : Operation
    {
        public float Execute(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
    class Division : Operation
    {
        public float Execute(float firstNumber, float secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}
