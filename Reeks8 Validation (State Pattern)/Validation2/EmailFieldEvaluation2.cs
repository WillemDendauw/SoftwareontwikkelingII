using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Validation2.Pattern;

namespace Validation2
{
    public enum ValidationState { INIT,WORD, POINT, DOMAIN_INIT, DOMAIN, DOMAIN_POINT, ACCEPT, FAULT};
    public class EmailFieldEvaluation2 : IFieldEvaluation
    {
        Dictionary<ValidationState, IState> states;

        IState state;

        public EmailFieldEvaluation2()
        {
            states = new Dictionary<ValidationState, IState>();
            states[ValidationState.INIT] = new SeparatorState(ValidationState.WORD);
            states[ValidationState.WORD] = new WordState();
            states[ValidationState.POINT] = new SeparatorState(ValidationState.WORD);
            states[ValidationState.DOMAIN_INIT] = new SeparatorState(ValidationState.DOMAIN);
            states[ValidationState.DOMAIN] = new DomainState();
            states[ValidationState.DOMAIN_POINT] = new SeparatorState(ValidationState.ACCEPT);
            states[ValidationState.ACCEPT] = new DomainState();
            states[ValidationState.FAULT] = new FaultState();
        }

        public bool Evaluate(string text)
        {
            state = states[ValidationState.INIT];
            string pattern = @"(\w+)|(@)|(\.)";
            MatchCollection parts = Regex.Matches(text, pattern);

            bool stillValid = true;
            int tempIndex = 0;
            while(stillValid && tempIndex < parts.Count)
            {
                stillValid = state.IsNextValid(parts[tempIndex].Value, this);
                tempIndex++;
            }
            return state == states[ValidationState.ACCEPT];
        }

        internal ValidationState State
        {
            set
            {
                state = states[value];
            }
        }

        public override string ToString()
        {
            return "Email2";
        }

    }
}
