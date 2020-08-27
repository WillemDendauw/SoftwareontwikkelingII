using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrukMeterView.DecoratorPattern;

namespace DrukMeterView
{
    //Delegate voor push
    public delegate void CallBack(double druk, double maxDruk);

    //toegevoegd: afgeleid van interface
    public class DrukPascal: ISubject
    {
        private event CallBack Notify;
        private double druk = 101325, max = 1700000;

        public string Eenheid { get; } = "Pa";
        public string Naam { get; } = "Pascal";

        public double Max => max;

        public double Druk
        {
            get
            {
                return druk;
            }
            set
            {
                druk = Math.Max(0, Math.Min(value, Max));
                Notify?.Invoke(Druk, Max); //Notify if not null
            }
        }

        //Observer - push : deze klasse moet zelf push uitvoeren
        public void Add(CallBack method)
        {
            Notify += method;
        }
    }
}
