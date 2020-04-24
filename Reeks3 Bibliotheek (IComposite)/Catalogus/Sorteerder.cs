using System;
using System.Collections.Generic;
using System.Text;
using Catalogus.Pattern;

namespace Catalogus
{
    public class Sorteerder : Comparer<IBibItem>
    {
        public override int Compare(IBibItem x, IBibItem y)
        {
            if(x is Afdeling && !(y is Afdeling))
            {
                return -1;
            }
            if( y is Afdeling && !(x is Afdeling))
            {
                return 1;
            }
            if(y is Afdeling && x is Afdeling)
            {
                return Compare((Afdeling)x, (Afdeling)y);
            }
            if (x is Boek && !(y is Boek))
                return -1;
            if (y is Boek && !(x is Boek))
                return 1;
            if (x is Boek && y is Boek)
            {
                return Compare((Boek)x, (Boek)y);
            }
            if (x is Tijdschrift && !(y is Tijdschrift))
                return -1;
            if (y is Tijdschrift && !(x is Tijdschrift))
                return 1;
            if (x is Tijdschrift && y is Tijdschrift)
            {
                return Compare((Tijdschrift)x, (Tijdschrift)y);
            }
            return 0;
        }

        private int Compare(Afdeling x, Afdeling y)
        {
            string sx = x.Naam + " - " + x.Id;
            string sy = y.Naam + " - " + y.Id;
            return sx.CompareTo(sy);
        }

        private int Compare(Boek x, Boek y)
        {
            string sx = x.Auteur + " - " + x.Titel + " - " + x.Id;
            string sy = y.Auteur + " - " + y.Titel + " - " + y.Id; ;
            return sx.CompareTo(sy);
        }

        private int Compare(Tijdschrift x, Tijdschrift y)
        {
            string sx = x.Titel + " - " + x.Id;
            string sy = y.Titel + " - " + y.Id;
            if (sx != sy)
            {
                return sx.CompareTo(sy);
            }
            else
            {
                DateTime tijdX = x.Datum;
                DateTime tijdY = y.Datum;
                if(tijdX != tijdY)
                {
                    return tijdX.CompareTo(tijdY);
                }
                else
                {
                    return x.Id.CompareTo(y.Id);
                }
            }
        }
    }
}
