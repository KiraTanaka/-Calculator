using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Analysis.LexicalAnalysis;
using ConsoleCalculator.DistributorsOperations;
using ConsoleCalculator.Analysis.SyntacticAnalysis;
using ConsoleCalculator.UserInterfaces;
using ConsoleCalculator.Evaluations;
using ConsoleCalculator.DistributorsTokens;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Tokens tokens = new Tokens() { TokenNumber = true, ListTokens = new List<string>() { "*", "/", "+", "-", "(", ")" } };

            UserInterface userInterface = new UserInterfaceForExpression();
            Evaluation evaluation = new EvaluationOfExpression(new DistributorOfOperationsOfExpression());
            LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzerExpression(userInterface);
            SyntacticAnalyzer syntacticAnalyzer = new SyntacticAnalyzerExpression(userInterface,
                                                        new DistributorOfNextTokens(tokens));
            List<string> tokensExpression = new List<string>(); 
            string expression = "";
            while (true)
            {
                expression = userInterface.ReceivingData();
                tokensExpression = lexicalAnalyzer.Analysis(expression);
                if (syntacticAnalyzer.Analysis(tokensExpression))
                    userInterface.ResultOutput(evaluation.Calculation(tokensExpression).NumberToString());
            }
            
        }
    }
}
