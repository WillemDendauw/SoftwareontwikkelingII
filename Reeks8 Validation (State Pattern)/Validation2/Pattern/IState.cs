using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation2.Pattern
{
    interface IState
    {
        bool IsNextValid(string token, EmailFieldEvaluation2 validator);
    }
}
