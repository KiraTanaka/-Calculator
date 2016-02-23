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

            //функция удаляет парные скобки, стоящие в правильном порядке, из копии исхоодной строки
            //если остались скобки, значит выражение в строке синтаксически неверное
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

            //случаи описанные в регулярном выражении:
            //  =  |  +*  |  -)  |  (*/-)  |  (*(  |  )+-)  |  *начало строки*+  |  -*конец строки*
            Regex regularIncorrectExpression = new Regex(@"(=)|([+,\-,*,/]{2,})|([+,\-,*,/]\))|(\([+,\-,*,/]+\))|(\([+,\-,*,/]+\()|(\)[+,\-,*,/]+\))|(^[+,\-,*,/]+)|([+,\-,*,/]+$)");

            if (!regularIncorrectExpression.IsMatch(expression))
                correct = true;

            return correct;
        }

        public static bool CheckingOfNumbersBetweenSigns(string expression)
        {
            bool correct = false;

            //случаи описанные в регулярном выражении:
            //  7.89.5  |  98.  |  )876.8  |  )5  |  876.8(  |  5(
            Regex regularIncorrectExpression = new Regex(@"(([0-9]+\.){2,})|([0-9]+\.([+,\-,*,/]|\)|\())|(\)[0-9]+(\.[0-9]+)?)|([0-9]+(\.[0-9]+)?\()");

            if (!regularIncorrectExpression.IsMatch(expression))
                correct = true;

            return correct;
        }
    }
}
