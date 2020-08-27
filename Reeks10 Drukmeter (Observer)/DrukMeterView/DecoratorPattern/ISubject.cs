using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrukMeterView.DecoratorPattern
{
    public interface ISubject
    {
        double Druk { get; set; }

        string Eenheid { get; }
        string Naam { get; }

        double Max { get; }

        void Add(CallBack method);
    }
}
