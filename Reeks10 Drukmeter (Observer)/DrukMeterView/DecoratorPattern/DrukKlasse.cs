using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrukMeterView.DecoratorPattern
{
    public class DrukKlasse : ISubject
    {
        private ISubject pascal;

        public string Eenheid { get; }

        public string Naam { get; }

        public double Max { get; }
        public DrukKlasse(ISubject pascal, double factor, string eenheid, string naam)
        {
            this.pascal = pascal;
            this.Druk = pascal.Druk * factor;
            this.Naam = naam;
            this.Eenheid = eenheid;
            this.Max = pascal.Max;
        }

        public double Druk
        {
            get
            {
                return Druk;
            }
            set
            {
                Druk = Math.Max(0, Math.Min(value, Max));
            }
        }
    }
}
