using Coderingen;
using Coderingen.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeerZin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inlezen zin en uit te voeren codering(en)
            Console.Out.Write("Geef zin: ");
            string zin = Console.In.ReadLine();
            Console.Out.Write("Geef codering(en): ");
            string typeInvoer = Console.In.ReadLine();

            // Voer verschillende coderingen uit
            ICodering codering = Helper.MeerdereCoderingen(typeInvoer);

            // Gecodereerde zin afdrukken
            Console.Out.WriteLine(codering.Codeer(zin));
            Console.ReadKey();
        }
    }
}
