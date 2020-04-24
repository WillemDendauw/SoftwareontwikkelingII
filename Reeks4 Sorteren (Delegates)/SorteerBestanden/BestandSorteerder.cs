using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteerBestanden
{
    public delegate IList<T> SorteerType<T>(IList<T> lijst, IComparer<T> vergelijker);

    public delegate T LeesType<T>(string lijn);
    public class BestandSorteerder<T>
    {
        SorteerType<T> sorteerMethode;
        LeesType<T> leesMethode;
        IComparer<T> vergelijker;

        public BestandSorteerder(SorteerType<T> sorteerMethode, LeesType<T> leesMethode, IComparer<T> vergelijker)
        {
            this.sorteerMethode = sorteerMethode;
            this.leesMethode = leesMethode;
            this.vergelijker = vergelijker;
        }

        public void Parse(string invoer, string uitvoer)
        {
            IList<T> lijst = new List<T>();
            using(StreamReader sr = new StreamReader(invoer))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    lijst.Add(leesMethode(line));
                }
            }
            IList<T> gesorteerd = sorteerMethode(lijst, vergelijker);

            using(TextWriter tw = new StreamWriter(uitvoer))
            {
                foreach(T item in gesorteerd)
                {
                    tw.WriteLine(item);
                }
            }
        }
    }
}
