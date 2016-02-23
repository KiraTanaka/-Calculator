using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class ExpressionValidation
    {
        public static bool CheckingBrackets( string expression )
        {
            string copyOfExpression = String.Copy(expression);
            bool correct = false;
            int indexLeftBracket, indexRightBracket, counter;

            while ((copyOfExpression.IndexOf('(') < copyOfExpression.IndexOf(')')) 
                    && (copyOfExpression.IndexOf('(') >= 0) 
                    && (copyOfExpression.IndexOf(')') > 0))
            {
                counter = 0;
                indexLeftBracket = -1;
                indexRightBracket = -1;
                foreach (var symbol in copyOfExpression)
                {
                    if (symbol == '(')
                        indexLeftBracket = counter;
                    if ((indexLeftBracket >= 0) && (symbol == ')'))
                    {
                        indexRightBracket = counter;                       
                        copyOfExpression = copyOfExpression.Remove(indexRightBracket, 1);
                        copyOfExpression = copyOfExpression.Remove(indexLeftBracket, 1);
                        break;
                    }
                    counter++;
                }
            }

            if (copyOfExpression.IndexOf('(') == -1 && copyOfExpression.IndexOf(')') == -1)
                correct = true;

            return correct;
        }

        public static bool CheckingSigns(string expression)
        {
            bool correct = false;
            Regex regularIncorrectExpression = new Regex(@"(=)|([+,\-,*,/]{2,})|([+,\-,*,/]\))|(\([+,\-,*,/]\))|(\([+,\-,*,/]\()|(\)[+,\-,*,/]\))|(^\-)|([+,\-,*,/]$)");

            if (!regularIncorrectExpression.IsMatch(expression))
                correct = true;

            return correct;
        }
    }
}
