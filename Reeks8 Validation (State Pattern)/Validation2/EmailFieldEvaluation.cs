using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation2
{
    public class EmailFieldEvaluation : IFieldEvaluation
    {
        public bool Evaluate(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //toegevoegd voor GUI-applicatie
        public override string ToString()
        {
            return "Email";
        }
    }
}
