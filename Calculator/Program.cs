using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Analysis.LexicalAnalysis;
using ConsoleCalculator.GeneratorsOfOperations;
using ConsoleCalculator.Analysis.SyntacticAnalysis;
using ConsoleCalculator.UserInterfaces;
using ConsoleCalculator.Calculation;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterfaceForExpression();
            Evaluation evaluation = new EvaluationOfExpression(new GeneratorOfOperationsOfExpression());
            LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzerExpression(userInterface);
            SyntacticAnalyzer syntacticAnalyzer = new SyntacticAnalyzerExpression(userInterface);
            List<string> tokensExpression = new List<string>(); 
            string expression = "";
            while (true)
            {
                expression = userInterface.ReceivingData();
                tokensExpression = lexicalAnalyzer.Analysis(expression);
                if (syntacticAnalyzer.Analysis(tokensExpression))
                    userInterface.ResultOutput(evaluation.Calculation(tokensExpression).ToString());
            }
            
        }
    }
}
