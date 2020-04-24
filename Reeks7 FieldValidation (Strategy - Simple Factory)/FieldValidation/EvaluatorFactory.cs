using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation
{
    public class EvaluatorFactory
    {
        Dictionary<string, IFieldEvaluation> evaluators = new Dictionary<string, IFieldEvaluation>();
        public List<string> types => evaluators.Keys.ToList();

        public EvaluatorFactory()
        {
            evaluators["Number"] = new NumberFieldEvaluation();
            evaluators["Email"] = new BankFieldEvaluation();
            evaluators["Bank"] = new BankFieldEvaluation();
        }

        public IFieldEvaluation this[string type]
        {
            get
            {
                if (evaluators.Keys.Contains(type))
                {
                    return evaluators[type];
                }
                else
                {
                    return evaluators["Number"];
                }
            }
        }
    }
}
