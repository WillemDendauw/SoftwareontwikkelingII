using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorteren;

namespace SorteerBestanden
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type invoer: ");
            string type = Console.ReadLine();
            Console.Write("SorteerMethode: ");
            string sorteerMethode = Console.ReadLine();
            Console.Write("Geef invoerbestand: ");
            string invoer = Console.ReadLine();
            Console.Write("Geef uitvoerbestand: ");
            string uitvoer = Console.ReadLine();

            if(type == "school")
            {
                SchoolSorteerder vergelijker = new SchoolSorteerder();
                if (sorteerMethode == "selectie")
                {
                    BestandSorteerder<School> bs = new BestandSorteerder<School>(SorteerBib<School>.SelectieSorteer, SchoolLezer.LeesSchool, vergelijker);
                    bs.Parse(invoer, uitvoer);
                }
                else if(sorteerMethode == "bubble")
                {
                    BestandSorteerder<School> bs = new BestandSorteerder<School>(SorteerBib<School>.BubbleSorteer, SchoolLezer.LeesSchool, vergelijker);
                    bs.Parse(invoer, uitvoer);
                }
                else
                {
                    Console.WriteLine("Sorteermethode ongekend");
                }
            }
            else if (type == "park")
            {

                ParkSorteerder vergelijker = new ParkSorteerder();
                if (sorteerMethode == "selectie")
                {
                    BestandSorteerder<Park> bs = new BestandSorteerder<Park>(SorteerBib<Park>.SelectieSorteer, ParkLezer.LeesPark, vergelijker);
                    bs.Parse(invoer, uitvoer);
                }
                else if (sorteerMethode == "bubble")
                {
                    BestandSorteerder<Park> bs = new BestandSorteerder<Park>(SorteerBib<Park>.BubbleSorteer, ParkLezer.LeesPark, vergelijker);
                    bs.Parse(invoer, uitvoer);

                }
                else
                {
                    Console.WriteLine("sorteermethode ongekend");
                }
            }
            else
            {
                Console.WriteLine("Type ongekend");
            }
        }
    }
}
