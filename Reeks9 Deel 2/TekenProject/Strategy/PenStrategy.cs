using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TekenProject.Pattern;

namespace TekenProject.Strategy
{
    public class PenStrategy : LineStrategy
    {
        public PenStrategy(Helper helper, Canvas canvas) : base(helper, canvas)
        {

        }

        protected override bool CanMove => false;

        public override void MouseMove(Point p)
        {
            if (tweePunten)
            {
                start = einde;
            }
            base.MouseMove(p);
        }
    }
}
