using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public interface Operation
    {
        TypeNumber Execute(TypeNumber firstNumber, TypeNumber secondNumber);
    }
    class Addition : Operation
    {
        public TypeNumber Execute(TypeNumber firstNumber, TypeNumber secondNumber)
        {
            TypeNumber result = new TypeNumber();
            result.Number = firstNumber.Number + secondNumber.Number;
            return result;
        }
    }
    class Subtraction : Operation
    {
        public TypeNumber Execute(TypeNumber firstNumber, TypeNumber secondNumber)
        {
            TypeNumber result = new TypeNumber();
            result.Number = firstNumber.Number - secondNumber.Number;
            return result;
        }
    }
    class Multiplication : Operation
    {
        public TypeNumber Execute(TypeNumber firstNumber, TypeNumber secondNumber)
        {
            TypeNumber result = new TypeNumber();
            result.Number = firstNumber.Number * secondNumber.Number;
            return result;
        }
    }
    class Division : Operation
    {
        public TypeNumber Execute(TypeNumber firstNumber, TypeNumber secondNumber)
        {
            TypeNumber result = new TypeNumber();
            result.Number = firstNumber.Number / secondNumber.Number;
            return result;
        }
    }
}
