
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TekenProject.Pattern;

namespace TekenProject
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<Key, Pattern.ICommand> commands = new Dictionary<Key, Pattern.ICommand>();
        Pattern.ICommand command;
        Helper helper;

        public MainWindow()
        {
            InitializeComponent();
            helper = new Helper(this);
            InitCommands();
            canvas.Focus();
        }
        
        private void InitCommands()
        {
            commands.Add(Key.Cancel, new NoCommand(helper));
            commands.Add(Key.B, new BCommand(helper));
            commands.Add(Key.M, new MCommand(helper));
            commands.Add(Key.F, new FCommand(helper));
            commands.Add(Key.R, new RCommand(helper));
        }

        internal void ResetCommand()
        {
            command = commands[Key.Cancel];
        }

        #region MouseEvents       
        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            helper.MouseDown(e.GetPosition(canvas));
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            helper.MouseUp(e.GetPosition(canvas));
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
        #endregion

        #region reageren op de toetscombinatie F nr
        Key vorig = Key.Enter;
        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (commands.ContainsKey(e.Key))
            {
                command = commands[e.Key];
                
                if (command.NumberKeys == 1) {
                    command.Execute(e.Key);
                }
            }
            else
            {
                command.Execute(e.Key);
                ResetCommand();
            }
        }
        #endregion

        #region Draw methods
        private void DrawLine(Point start, Point eind)
        {
            Line line = new Line();
            line.Stroke = Brushes.Blue;
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = eind.X;
            line.Y2 = eind.Y;
            canvas.Children.Add(line);
        }

        private void DrawEllips(Point start, Point eind)
        {           
            Shape shape = new Ellipse();
            shape.Width = Math.Abs(eind.X - start.X);
            shape.Height = Math.Abs(eind.Y - start.Y);
            shape.Stroke = Brushes.Black;
            shape.Fill = Brushes.Red;

            Canvas.SetLeft(shape, Math.Min(start.X, eind.X));
            Canvas.SetTop(shape, Math.Min(start.Y, eind.Y));
            canvas.Children.Add(shape);
        }
        #endregion
        

        #region Button_Click events aanvullen
        private void btnStroke_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPencil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
