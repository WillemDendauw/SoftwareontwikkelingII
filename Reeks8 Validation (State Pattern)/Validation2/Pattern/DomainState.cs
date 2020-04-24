using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation2.Pattern
{
    public class DomainState : IState
    {
        public bool IsNextValid(string token, EmailFieldEvaluation2 validator)
        {
            if(token == ".")
            {
                validator.State = ValidationState.DOMAIN_POINT;
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
