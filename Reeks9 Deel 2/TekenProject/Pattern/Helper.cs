using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TekenProject.Pattern.Commands;
using TekenProject.Strategy;

namespace TekenProject.Pattern
{
    public class Helper
    {
        SolidColorBrush[] colors = { Brushes.Black, Brushes.White, Brushes.Gray, Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Yellow, Brushes.Purple, Brushes.Brown, Brushes.Orange };

        StrategyFactory factory;
        IStrategy strategy;

        MainWindow window;
        int strokeNr = 0, fillNr = 1;

        public Helper(MainWindow window)
        {
            this.window = window;
            factory = new StrategyFactory(this, window.canvas);
        }

        internal void setStrategy(int selected)
        {
            strategy = factory[selected];
        }
        
        internal SolidColorBrush StrokeColor => colors[StrokeNr];
        internal SolidColorBrush FillColor => colors[FillNr];

        internal int StrokeNr
        {
            get { return strokeNr; }
            set
            {
                strokeNr = value % colors.Length;
                window.brushStroke.Color = StrokeColor.Color;
            }
        }

        internal int FillNr
        {
            get { return fillNr; }
            set
            {
                fillNr = value % colors.Length;
                window.brushFill.Color = FillColor.Color;
            }
        }
        internal void ClearCanvas()
        {
            window.canvas.Children.Clear();
        }

        internal void MouseDown(Point point)
        {
            strategy.MouseDown(point);
        }

        internal void MouseUp(Point point)
        {
            strategy.MouseUp(point);
        }

        internal void MouseMove(Point point)
        {
            strategy.MouseMove(point);
        }

        
        #region Draw methods
        /*
        private void DrawLine(Point start, Point eind)
        {
            Line line = new Line();
            line.Stroke = StrokeColor;// Brushes.Blue;
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = eind.X;
            line.Y2 = eind.Y;
            window.canvas.Children.Add(line);
        }

        private void DrawEllips(Point start, Point eind)
        {
            Console.Write(""+StrokeNr+" "+ FillNr);
            Shape shape = new Ellipse();
            shape.Width = Math.Abs(eind.X - start.X);
            shape.Height = Math.Abs(eind.Y - start.Y);
            shape.Stroke = StrokeColor;// Brushes.Black;
            shape.Fill = FillColor;

            Canvas.SetLeft(shape, Math.Min(start.X, eind.X));
            Canvas.SetTop(shape, Math.Min(start.Y, eind.Y));
            window.canvas.Children.Add(shape);
        }
        */
        #endregion
    }

}