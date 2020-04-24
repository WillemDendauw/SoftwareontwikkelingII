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

        public override string Codeer(string zin)
        {
            zin = codering.Codeer(zin);
            if(zin.Length % 2 != 0)
            {
                zin += "0";
            }
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < zin.Length; i+=2)
            {
                result.Append(zin[i + 1]);
                result.Append(zin[i]);
            }
            return result.ToString();
        }
    }
}
