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
    public class LineStrategy : AStrategy
    {
        public LineStrategy(Helper helper, Canvas canvas) : base(helper, canvas)
        {

        }

        protected override Shape GetShape()
        {
            return new Line();
        }

        protected override void InitShape()
        {
            Line line = (Line)shape;
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = einde.X;
            line.Y2 = einde.Y;
            shape = line;
        }
    }
}
