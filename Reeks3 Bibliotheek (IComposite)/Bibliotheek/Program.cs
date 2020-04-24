using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogus.Pattern;

namespace Bibliotheek
{
    class Program
    {
        static void Main(string[] args)
        {
            DummyBibliotheek bib = new DummyBibliotheek();
            IBibItem start = bib.Bibliotheek;
            IBibItem item = start.Zoek("ID07");
            Console.WriteLine(item.Toon(0) + "\n");
            Console.WriteLine(start.Toon(0));
            ISet<IBibItem> gevonden = start.ZoekTrefwoord("en");
            foreach(IBibItem ib in gevonden)
            {
                Console.WriteLine(ib.Toon(0));
            }
            Console.ReadKey();
        }
    }
}
