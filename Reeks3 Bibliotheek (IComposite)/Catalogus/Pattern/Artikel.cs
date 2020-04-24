using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogus.Pattern
{
    public class Artikel : ABibItem
    {
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public override string Inhoud
        {
            get { return Id + ": \"" + Titel + "\", " + Auteur; }
        }

        public override bool HasTrefwoord(string trefwoord)
        {
            return Auteur.Contains(trefwoord) || Titel.Contains(trefwoord);
        }
    }
}
