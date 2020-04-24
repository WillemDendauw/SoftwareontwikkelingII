
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EersteProject
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Geef naam: ");
            string naam = Console.ReadLine();
            Persoon p = new Persoon(naam);
            Console.WriteLine(p.WelcomeMessage);
            */

            Persoon s = new Student("John DOOOO", 696969);
            string output = s.WelcomeMessage;
            Console.WriteLine(output);

            if(s is Student)
            {
                Console.Out.WriteLine("s - Is Student");
            }

            if(s is Persoon)
            {
                Console.Out.WriteLine("s - Is Persoon");
            }

            Console.Out.WriteLine("type van s = " + s.GetType());

            if(s is Student)
            {
                string output2 = ((Student)s).DoSomething();
                Console.Out.WriteLine(output2);
            }

            Console.ReadKey(); //zodat console open blijft
        }
    }
}
