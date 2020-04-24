using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    public abstract class ACodering : ICodering
    {
        protected ICodering codering;
		public ACodering(ICodering codering)
        {
            this.codering = codering;
        }

        public abstract string Codeer(string zin);
    }
}
