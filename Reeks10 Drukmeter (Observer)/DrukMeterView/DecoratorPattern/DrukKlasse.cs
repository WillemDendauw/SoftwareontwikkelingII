using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrukMeterView.DecoratorPattern
{
    public class DrukKlasse : ISubject
    {
        //decorator-pattern, enkel voor druk
        //Observer moet in de klasse staan bij pull (juiste informatie doorgeven!)

        public event CallBack Notify;
        
        ISubject drukPascal;

        private double factor;
        private string eenheid, naam;
        public DrukKlasse(ISubject drukPascal, double factor, string eenheid, string naam)
        {
            this.drukPascal = drukPascal;
            this.factor = factor;
            this.naam = naam;
            this.eenheid = eenheid;
        }

        public string Eenheid => eenheid;
        public string Naam => naam;

        public double Druk
        {
            get
            {
                return drukPascal.Druk / factor;
            }
            set
            {
                drukPascal.Druk = value * factor;
                Notify?.Invoke(Druk, Max); //notify if not null
            }
        }

        public double Max
        {
            get { return drukPascal.Max / factor; }
        }

        public void Add(CallBack method)
        {
            Notify += method;
        }
    }
}
