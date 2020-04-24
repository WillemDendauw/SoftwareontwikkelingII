using Coderingen.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen
{
    public class Helper
    {
        /// <summary>
        /// Hulpmethode om meerdere coderingen na elkaar uit te voeren op een gegeven component
        /// </summary>
        /// <param name="types">de verschillenden coderingen, gescheiden door een spatie (bv. blok wissel blok)</param>
        /// <returns>Het resultaat van de verschillende coderingen</returns>
        public static ICodering MeerdereCoderingen(string types)
        {
            ICodering codering = new BasisCodering();
            // verschillende coderingen toepassen

            foreach (string type in types.Split(' '))
            {
                // type blok
                if (type == "blok")
                {
                    codering = new BlokCodering(codering);
                }
                else if (type == "wissel")
                {
                    codering = new WisselCodering(codering);
                }
                else
                {
                    codering = new CijferCodering(codering);
                }
            }
            return codering;
        }
    }
}
