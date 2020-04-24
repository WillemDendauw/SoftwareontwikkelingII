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

        /// <summary>
        ///
        /// </summary>
        /// <param name="codering">object om te decoreren</param>
        public ACodering(ICodering codering)
        {
            this.codering = codering;
        }

        /// <summary>
        /// Methode uit interface als abstracte methode.
        /// De verschillende decorators implementeren deze methode.
        /// </summary>
        /// <param name="zin"></param>
        /// <returns></returns>
        public string Codeer(string zin)
        {
            zin = codering.Codeer(zin);
            zin = zin.ToLower();
            StringBuilder zinBuffer = SpatieVerwijderen(zin);
            zinBuffer = VerwijderSpecialeTekens(zinBuffer);
            if (AddEven())
            {
                zinBuffer = MaakEven(zinBuffer);
            }
            zin = (zinBuffer).ToString();
            return zin;
        }

        protected StringBuilder MaakEven(StringBuilder zinBuffer)
        {
            if(zinBuffer.Length % 2 != 0)
            {
                zinBuffer.Append('0');
            }
            return zinBuffer;
        }

        protected abstract StringBuilder Codeer(StringBuilder zinBuffer);
        protected virtual bool AddEven()
        {
            return true;
        }

        private StringBuilder VerwijderSpecialeTekens(StringBuilder zinBuffer)
        {
            for(int i =0; i < zinBuffer.Length; i++)
            {
                if(!char.IsLower(zinBuffer[i]) && !char.IsDigit(zinBuffer[i])){
                    zinBuffer[i] = '0';
                }
            }
            return zinBuffer;
        }

        private StringBuilder SpatieVerwijderen(string zin)
        {
            string[] woorden = zin.Split(' ');
            StringBuilder zinBuffer = new StringBuilder();
            int n = woorden.Length;
            for(int i = 0; i < n-1; i++)
            {
                zinBuffer.Append(woorden[i]);
                zinBuffer.Append('0');
            }
            zinBuffer.Append(woorden[n - 1]);
            return zinBuffer;
        }
    }

}
