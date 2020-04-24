using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation
{
    public class EmailFieldEvaluation : IFieldEvaluation
    {
        public bool Evaluate(string s)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(s);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Email";
        }
    }
}
