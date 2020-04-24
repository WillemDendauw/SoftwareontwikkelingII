using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation
{
    public interface IFieldEvaluation
    {
        bool Evaluate(string s);
    }
}
