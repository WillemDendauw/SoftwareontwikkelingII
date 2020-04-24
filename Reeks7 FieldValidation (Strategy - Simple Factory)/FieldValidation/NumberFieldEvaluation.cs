using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FieldValidation
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

        public override string ToString()
        {
            return "Number";
        }
    }
}
