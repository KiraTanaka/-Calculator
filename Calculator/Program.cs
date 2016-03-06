using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.LexicalAnalysis;
using ConsoleCalculator.Generator;
using ConsoleCalculator.SyntacticAnalysis;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntacticAnalyzerExpression analyzer = new SyntacticAnalyzerExpression();
            List<string> tokensExpression = new List<string>();

            tokensExpression.Add("-2");
            tokensExpression.Add("*");
            tokensExpression.Add("(");
            tokensExpression.Add("3");
            tokensExpression.Add("+");
            tokensExpression.Add("5.8");
            tokensExpression.Add(")");
            tokensExpression.Add("+");
            tokensExpression.Add("(");
            tokensExpression.Add("7");
            tokensExpression.Add("-");
            tokensExpression.Add("3");
            tokensExpression.Add(")");
            analyzer.Analysis(tokensExpression);
            //UserInterface userInterface = new UserInterfaceForExpression();
            //Evaluation evaluation = new EvaluationOfExpression(new GeneratorOfOperation());
            //string expression = "";
            //while (true)
            //{
            //    expression = userInterface.ReceivingData();
            //    if (ExpressionValidation.FullValidation(ref expression))
            //        userInterface.ResultOutput(evaluation.Calculation(expression).ToString());
            //}
            
        }
    }
}
