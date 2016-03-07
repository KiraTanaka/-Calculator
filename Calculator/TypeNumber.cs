using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class TypeNumber
    {
        public float Number { get; set; }

        public static float TryParse(string lineWithLine)
        {
            float result;
            float.TryParse(lineWithLine, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result);
            return result;
        }
        public string NumberToString()
        {
            return Number.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
