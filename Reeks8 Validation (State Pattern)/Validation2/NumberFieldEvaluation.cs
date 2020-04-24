using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation2
{
    public class NumberFieldEvaluation : IFieldEvaluation
    {
        public bool Evaluate(string s)
        {
            try
            {
                double getal = Double.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //toegevoegd voor GUI-applicatie
        public override string ToString()
        {
            return "Number";
        }
    }
}
