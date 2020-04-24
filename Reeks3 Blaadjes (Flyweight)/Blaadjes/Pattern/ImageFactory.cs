using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaadjes.Pattern
{
    public class ImageFactory
    {
        public static string[] SOORTEN = { "blad", "groenBlad", "roodBlad", "pluim" };
        private Dictionary<string, IImage> afbeeldingen;
        private Random random = new Random();

        public ImageFactory()
        {
            afbeeldingen = new Dictionary<string, IImage>();
            //direct alle 4 de objecten aanmaken
            foreach(string soort in SOORTEN)
            {
                string bestandsnaam = "images\\" + soort + ".png";

                IImage afbeelding;
                if (soort.Equals("pluim"))
                {
                    afbeelding = new Feather(bestandsnaam);
                }
                else
                {
                    afbeelding = new Leaf(bestandsnaam);
                }
                afbeeldingen.Add(soort, afbeelding);
            }
        }

        public IImage this[string soort]
        {
            get { return afbeeldingen[soort];  }
        }

        public IImage KiesBlad()
        {
            int k = random.Next(afbeeldingen.Count - 1); //laatste niet
            return afbeeldingen[SOORTEN[k]];
        }
    }
}
