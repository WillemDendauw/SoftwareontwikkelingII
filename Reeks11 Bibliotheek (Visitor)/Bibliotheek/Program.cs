using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheek.Pattern;

namespace Bibliotheek
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            //Console.Out.WriteLine("Aantal items: " + library.Items.Count);

            Versie1(library);
            Console.Out.WriteLine();

            Versie2(library);
            Console.Out.WriteLine();

            ShowTitles(library);
            
            Console.ReadKey();
        }

        private static void Versie1(Library library)
        {
            IVisitor visitor = new CountVisitor();
            visitor.Visit(library);

            IVisitor visitor2 = new AuteursVisitor();
            visitor2.Visit(library);
        }

        private static void Versie2(Library library)
        {
            PatternReflectie.IVisitor visitor = new PatternReflectie.PrintVisitor();
            visitor.Visit(library);

            PatternReflectie.IVisitor visitor2 = new PatternReflectie.AuteursVisitor();
            visitor2.Visit(library);
        }

        private static void ShowTitles(Library library)
        {
            Console.WriteLine("\nInhoud Bibliotheek: ");
            foreach(string title in library.Titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
