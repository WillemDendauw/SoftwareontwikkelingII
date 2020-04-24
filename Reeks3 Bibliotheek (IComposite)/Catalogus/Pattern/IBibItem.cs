using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogus.Pattern
{
    public interface IBibItem
    {
        string Id { get; set; }
        IBibItem Ouder { get; set; }
        void VoegToe(IBibItem bibitem);
        void Verwijder(IBibItem bibitem);
        IBibItem Zoek(string id);
        ISet<IBibItem> ZoekTrefwoord(string trefwoord);
        void VerplaatsNaar(IBibItem bibitem);
        string Toon(int insprong);
    }
}
