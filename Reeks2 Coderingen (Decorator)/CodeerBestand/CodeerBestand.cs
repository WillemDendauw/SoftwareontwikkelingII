using System;
using System.IO;
using Coderingen;
using Coderingen.Pattern;

namespace CodeerBestand
{
    class CodeerBestand
    {
        static void Main(string[] args)
        {
            Console.Out.Write("Geef bestandsnaam in voor invoer: ");
            string bestandIn = Console.In.ReadLine();
            Console.Out.Write("Geef bestandsnaam in voor uitvoer: ");
            string bestandUit = Console.In.ReadLine();
            Console.Out.Write("Geef codering: ");
            string typeInvoer = Console.In.ReadLine();

            ICodering codering = Helper.MeerdereCoderingen(typeInvoer);

            using (StreamReader bInvoer = new StreamReader(bestandIn))
            {
                StreamWriter bUitvoer = new StreamWriter(bestandUit);
                while (!bInvoer.EndOfStream)
                {
                    bUitvoer.WriteLine(codering.Codeer(bInvoer.ReadLine()));
                }
                bUitvoer.Close();
            }
        }
    }
}
