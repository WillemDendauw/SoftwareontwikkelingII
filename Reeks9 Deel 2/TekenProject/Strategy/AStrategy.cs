using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using TekenProject.Pattern;

namespace TekenProject.Strategy
{
    public abstract class AStrategy : IStrategy
    {
        protected Helper helper;
        private Canvas canvas;
        protected Shape shape;
        protected Point start, einde;
        protected bool tweePunten = false;

        public AStrategy(Helper helper, Canvas canvas)
        {
            this.helper = helper;
            this.canvas = canvas;
        }

        protected abstract Shape GetShape();

        public void MouseDown(Point p)
        {
            start = p;
            shape = GetShape();
            tweePunten = false;
        }

        public void MouseUp(Point p)
        {
            MouseMove(p);
            shape = null;
        }
        
        public virtual void MouseMove(Point p)
        {
            tweePunten = true;
            einde = p;
            Draw(canvas);
        }

        protected virtual void Draw(Canvas canvase)
        {
            if(shape != null)
            {
                if (CanMove)
                {
                    canvas.Children.Remove(shape);
                }
                else
                {
                    shape = GetShape();
                }
                shape.Stroke = helper.StrokeColor;
                InitShape();
                canvas.Children.Add(shape);
            }
        }

        protected abstract void InitShape();

        protected virtual bool CanMove => true;
    }
}
