using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TekenProject.Strategy
{
    public interface IStrategy
    {
        void MouseDown(Point p);
        void MouseUp(Point p);
        void MouseMove(Point p);
    }
}
