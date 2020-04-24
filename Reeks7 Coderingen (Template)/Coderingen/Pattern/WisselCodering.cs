using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    public class WisselCodering : ACodering
    {
        public WisselCodering(ICodering codering) : base(codering)
        {

        }

        protected override StringBuilder Codeer(StringBuilder zin)
        {
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < zin.Length; i+=2)
            {
                result.Append(zin[i + 1]);
                result.Append(zin[i]);
            }
            return result;
        }
    }
}
