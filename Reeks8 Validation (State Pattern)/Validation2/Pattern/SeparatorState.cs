using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation2.Pattern
{
    public class SeparatorState : IState
    {
        ValidationState next;
        internal SeparatorState(ValidationState next)
        {
            this.next = next;
        }

        public bool IsNextValid(string token, EmailFieldEvaluation2 validator)
        {
            if(token != "." && token !="@" && token != "" && !token.Contains(" "))
            {
                validator.State = next;
                return true;
            }
            else
            {
                validator.State = ValidationState.FAULT;
                return false;
            }
        }
    }
}
