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
    public class RectangleStrategy : AStrategy
    {
        public RectangleStrategy(Helper helper, Canvas canvas) : base(helper, canvas)
        {

        }

        protected override Shape GetShape()
        {
            return new Rectangle();
        }

        protected override void InitShape()
        {
            shape.Width = Math.Abs(einde.X - start.X);
            shape.Height = Math.Abs(einde.Y - start.Y);
            shape.Fill = helper.FillColor;
            Canvas.SetLeft(shape, Math.Min(start.X, einde.X));
            Canvas.SetTop(shape, Math.Min(start.Y, einde.Y));
        }
    }
}
