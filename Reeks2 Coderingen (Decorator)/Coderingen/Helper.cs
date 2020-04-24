using System;
using Coderingen.Pattern;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen
{
    public class Helper
    {
        public static ICodering MeerdereCoderingen(string types)
        {
            ICodering codering = new BasisCodering();

            foreach(string type in types.Split(' '))
            {
                if(type == "blok")
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
