using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.LexicalAnalysis;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterfaceForExpression();
            Evaluation evaluation = new EvaluationOfExpression(new GeneratorOfOperation());
            string expression = "";
            while (true)
            {
                expression = userInterface.ReceivingData();
                if (ExpressionValidation.FullValidation(ref expression))
                    userInterface.ResultOutput(evaluation.Calculation(expression).ToString());
            }
            
        }
    }
}
