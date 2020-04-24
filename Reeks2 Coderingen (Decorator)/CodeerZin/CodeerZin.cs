using System;
using Coderingen;
using Coderingen.Pattern;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen
{
    class CodeerZin
    {
        static void main(string[] args)
        {
            Console.Out.Write("Geef zin: ");
            string zin = Console.ReadLine();
            Console.Out.Write("Geef Codering(en) in: ");
            string typeInvoer = Console.ReadLine();

            ICodering codering = Helper.MeerdereCoderingen(typeInvoer);

            Console.Out.WriteLine(codering.Codeer(zin));
            Console.ReadKey();
        }
    }
}
