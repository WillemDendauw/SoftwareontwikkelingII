using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TekenProject.Pattern;

namespace TekenProject.Strategy
{
    public class StrategyFactory
    {
        Dictionary<int, IStrategy> strategys = new Dictionary<int, IStrategy>();

        public StrategyFactory(Helper helper, Canvas canvas)
        {
            strategys.Add(1, new PenStrategy(helper, canvas));
            strategys.Add(2, new LineStrategy(helper, canvas));
            strategys.Add(3, new RectangleStrategy(helper, canvas));
            strategys.Add(4, new EllipseStrategy(helper, canvas));
        }

        public IStrategy this[int nr]
        {
            get
            {
                if (strategys.ContainsKey(nr))
                {
                    return strategys[nr];
                }
                else
                {
                    return strategys[2];
                }
            }
        }
    }
}
