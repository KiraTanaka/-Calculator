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
            while (true)
            {
                Console.WriteLine("Введите выражение:");
                Console.WriteLine("(десятичные числа записывать через '.', например: 5.678)");
                Console.WriteLine("(отрицательные числа записывать в скобках, например: (-5.678))\n");
                expression = Console.ReadLine();
                Console.WriteLine("\n");
                if (ExpressionValidation.FullValidation(ref expression))
                {
                    result = EvaluationOfExpression.Evaluation(expression);
                    Console.WriteLine(String.Format("Результат вычисления:\n\n" + result));
                }
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
    }
}
