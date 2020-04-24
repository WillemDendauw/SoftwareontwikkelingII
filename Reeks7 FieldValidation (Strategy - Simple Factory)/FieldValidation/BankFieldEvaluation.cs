using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation
{
    public class BankFieldEvaluation : IFieldEvaluation
    {
        public bool Evaluate(string s)
        {
            string[] parts = s.Split('-');
            if(parts[0].Length != 3 || parts[1].Length != 7 || parts[2].Length != 2)
            {
                return false;
            }
            string getalstring = parts[0] + parts[1];
            try
            {
                int getal = Int32.Parse(getalstring);
                int rest = Int32.Parse(parts[2]);

                return (getal % 97 == rest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public override string ToString()
        {
            return "Bank Account";
        }
    }
}
