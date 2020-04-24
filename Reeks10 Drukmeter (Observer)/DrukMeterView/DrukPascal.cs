using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrukMeterView.DecoratorPattern;

namespace DrukMeterView
{
    public class DrukPascal: ISubject
    {
        private double druk = 101325;

        public string Eenheid { get; } = "Pa";
        public string Naam { get; } = "Pascal";

        public double Max { get; } = 1700000;

        private List<IObserver> observers = new List<IObserver>();

        //enkel teovoegen
        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
            observer.Update();
        }

        private void Notify()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update();
            }
        }

        public double Druk
        {
            get
            {
                return druk;
            }
            set
            {
                druk = Math.Max(0, Math.Min(value, Max));
                Notify();
            }
        }
    }
}
