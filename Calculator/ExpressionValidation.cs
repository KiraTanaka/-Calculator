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
        public static bool FullValidation(ref string expression)
        {
            CheckOnUnnecessarySymbols(ref expression);
            if (CheckingBrackets(expression) && CheckingOfNumbersBetweenSigns(expression) && CheckingSigns(expression))
                return true;
            else
                return false;
        }

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
            else
                Console.WriteLine("Выражение записано неверно. Проблема со скобками. Проверьте, что они стоят в правильном порядке и у каждой есть пара.");

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
            else
                Console.WriteLine("Выражение записано неверно. Проблема со знаками. Возможно вы где-то забыли написать число.");
            return correct;
        }

        public static bool CheckingOfNumbersBetweenSigns(string expression)
        {
            bool correct = false;

            //случаи описанные в регулярном выражении:
            //  7.89.5  |  98.+  |  )876.8  |  )5  |  876.8(  |  5(  |  )(  |  ()  |  (.)  |  ).(  |  ).8  |  98.(  |  *.8
            Regex regularIncorrectExpression = new Regex(@"(([0-9]+\.){2,})|([0-9]+(\.[0-9]+)?\.([+,\-,*,/]|\)|\())|(\)[0-9]+(\.[0-9]+)?)|([0-9]+(\.[0-9]+)?\()|\(\)|\)\(|\([0-9]+(\.[0-9]+)?\)|\(\.\)|\)\.\(|\)\.[0-9]+(\.[0-9]+)?|[+,\-,*,/]\.[0-9]+(\.[0-9]+)?");

            if (!regularIncorrectExpression.IsMatch(expression))
                correct = true;
            else
                Console.WriteLine("Выражение записано неверно. Проблема с числами. Также возможно вы забыли знак между числом и скобкой.");
            return correct;
        }

        public static bool CheckOnUnnecessarySymbols(ref string expression)
        {
            Regex regularUnnecessarySymbols = new Regex(@"\s|[a-z]|[A-Z]|[а-я]|[А-Я]|[\,,!,@,',`,#,№,\$,\;,%,\^,:,&,?,<,>,\[,\],\{,\},~,=,_,\|,\\]");
            if (regularUnnecessarySymbols.IsMatch(expression))
            {
                expression = regularUnnecessarySymbols.Replace(expression, "");
                Console.WriteLine("В выражении были найдены и удалены ненужные символы.");
                Console.WriteLine("Список ненужных символов в выражениях: [a-z], space,[A-Z], [а-я], [А-Я], ,, !, @, ', `, #, №, $, ;, %, ^, :, &, ?, <, >, [, ], {, }, ~, =, _, |,\\");
                Console.WriteLine("Будет вычислено выражение:\n\n" + expression + "\n\n");
                return true;
            }
            else
                return false;
        }
    }
}
