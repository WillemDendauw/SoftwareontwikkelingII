using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blaadjes.Pattern
{
    public class Feather : AImage
    {
        public Feather(string bestandsnaam) : base(bestandsnaam) { 
        }

        public override Point Move(Point p)
        {
            p.X = Math.Max(0, p.X - (w / 2));
            p.Y = p.Y + h / 2;
            return p;
        }
    }
}
