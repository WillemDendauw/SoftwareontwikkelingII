using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation2.Pattern
{
    public class WordState : IState
    {
        public bool IsNextValid(string token, EmailFieldEvaluation2 validator)
        {
            if(token == ".")
            {
                validator.State = ValidationState.POINT;
                return true;
            }
            else if (token == "@")
            {
                validator.State = ValidationState.DOMAIN_INIT;
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
