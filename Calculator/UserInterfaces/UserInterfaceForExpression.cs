using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.UserInterfaces
{
    public class UserInterfaceForExpression : UserInterface
    {
        public string ReceivingData()
        {
            string expression = "";
            Console.WriteLine("Введите выражение:");
            Console.WriteLine("(десятичные числа записывать через '.', например: 5.678)");
            Console.WriteLine("(отрицательные числа записывать в скобках, например: (-5.678))\n");
            expression = Console.ReadLine();
            Console.WriteLine("\n");

            return expression.Trim();
        }

        public void ResultOutput(string result)
        {
            Console.WriteLine(String.Format("Результат вычисления:\n\n" + result));
            Console.WriteLine("\n");
            Console.ReadLine();
        }
        public void DisplaysErrorMessage(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
