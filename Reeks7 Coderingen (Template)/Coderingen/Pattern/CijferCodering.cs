using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    public class CijferCodering : ACodering
    {
        public CijferCodering(ICodering codering) : base(codering)
        {
        }

        protected override StringBuilder Codeer(StringBuilder zin)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < zin.Length; i++)
            {
                int code = zin[i];
                result.Append(code);
            }
            return result;
        }

        protected override bool AddEven()
        {
            return false;
        }
    }
}
