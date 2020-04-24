using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using TekenProject.Pattern;

namespace TekenProject.Strategy
{
    public class EllipseStrategy : RectangleStrategy
    {
        public EllipseStrategy(Helper helper, Canvas canvas) : base(helper, canvas)
        {

        }

        protected override Shape GetShape()
        {
            return new Ellipse();
        }
    }
}
