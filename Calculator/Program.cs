using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "";
            float result = 0;
            Console.WriteLine("Введите выражение:");
            Console.WriteLine("(десятичные числа записывать через '.', например: 5.678)");
            expression = Console.ReadLine();
            if (ExpressionValidation.FullValidation(expression))
                result = EvaluationOfExpression.Evaluation(expression);
            Console.WriteLine(String.Format("Результат вычисления:\n" + result));
            Console.ReadLine();
        }
    }
}
