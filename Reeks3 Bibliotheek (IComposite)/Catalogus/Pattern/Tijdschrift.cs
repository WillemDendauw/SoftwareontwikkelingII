using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogus.Pattern
{
    public class Tijdschrift : ABibComposite
    {
        public DateTime Datum { get; set; }
        public string Uitgeverij { get; set; }
        public string Titel { get; set; }

        public Tijdschrift()
        {
            elementen = new List<IBibItem>();
        }

        public override string Inhoud
        {
            get
            {
                return Id + ": \"" + Titel + "\", "+ Datum.ToString("d/MM/yyyy H:mm:ss") + ", " +Uitgeverij;
            }
        }

        public override bool HasTrefwoord(string trefwoord)
        {
            return Titel.Contains(trefwoord) || Uitgeverij.Contains(trefwoord);
        }
    }
}
