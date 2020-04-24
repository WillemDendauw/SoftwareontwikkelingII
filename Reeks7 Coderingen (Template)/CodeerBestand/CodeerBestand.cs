using Coderingen;
using Coderingen.Pattern;
using System;
using System.IO;

namespace CodeerBestand
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.Write("Geef bestandsnaam voor invoer: ");
            string bestandIn = Console.In.ReadLine();
            Console.Out.Write("Geef bestandsnaam voor uitvoer: ");
            string bestandUit = Console.In.ReadLine();
            Console.Out.Write("Geef codering: ");
            string typeInvoer = Console.In.ReadLine();

            // Voer verschillende coderingen uit
            ICodering codering = Helper.MeerdereCoderingen(typeInvoer);

            // Bestand inlezen, coderen en wegschrijven
            using (StreamReader bInvoer = new StreamReader(bestandIn))
            {
                StreamWriter bUitvoer = new StreamWriter(bestandUit);
                while (!bInvoer.EndOfStream)
                {
                    // lijn inlezen, coderen en afdrukken
                    bUitvoer.WriteLine(codering.Codeer(bInvoer.ReadLine()));
                }
                bUitvoer.Close();
            }


        }
    }
}
