using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator.Analysis.LexicalAnalysis;
using ConsoleCalculator.Factories;
using ConsoleCalculator.Analysis.SyntacticAnalysis;
using ConsoleCalculator.UserInterfaces;
using ConsoleCalculator.Evaluations;
using ConsoleCalculator.DistributorsTokens;
using ConsoleCalculator.Tokens;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IUserInterface userInterface = new UserInterfaceForExpression();
                Evaluation evaluation = new EvaluationOfExpression();
                ILexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzerExpression(userInterface);
                ISyntacticAnalyzer syntacticAnalyzer = new SyntacticAnalyzerExpression(userInterface);
                List<Token> tokensExpression;
                string expression = "";

                expression = userInterface.ReceivingData();
                tokensExpression = lexicalAnalyzer.Analysis(expression);
                if (tokensExpression != null && syntacticAnalyzer.Analysis(tokensExpression))
                    userInterface.ResultOutput(evaluation.Calculation(tokensExpression).NumberToString());
            }       
        }
    }
}
