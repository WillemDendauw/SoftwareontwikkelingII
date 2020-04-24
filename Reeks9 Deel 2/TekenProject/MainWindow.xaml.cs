
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TekenProject.Pattern;
using TekenProject.Pattern.Commands;

namespace TekenProject
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<Key, Pattern.Commands.ICommand> commands = new Dictionary<Key, Pattern.Commands.ICommand>();
        Pattern.Commands.ICommand command;//huidige commando
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
            commands.Add(Key.F, new FCommand(helper));
            commands.Add(Key.M, new MCommand(helper));
            commands.Add(Key.R, new RCommand(helper));
            ResetCommand();
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

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {

            if (commands.ContainsKey(e.Key))
            {
                command = commands[e.Key];
                if (command.NumberKeys == 1)
                {
                    command.Execute(e.Key);//moet direct worden uitgevoegd bij R-toets
                }
            }
            else
            {
                command.Execute(e.Key);
                ResetCommand();
            }
        }


        private void btnFill_Click(object sender, RoutedEventArgs e)
        {

            helper.FillNr++;
        }

        private void btnStroke_Click(object sender, RoutedEventArgs e)
        {
            helper.StrokeNr++;
        }

        private void btnPencil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            commands[Key.M].Execute(Key.D2);
        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {
            commands[Key.M].Execute(Key.D4);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            commands[Key.R].Execute(Key.None);//Key maakt niet uit
        }

    }
}
