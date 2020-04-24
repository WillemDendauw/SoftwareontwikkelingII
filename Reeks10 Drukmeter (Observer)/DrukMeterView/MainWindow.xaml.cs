using System;
using System.Windows;
using System.Windows.Controls;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Control invoer, Control uitvoer)
            : this()
        {
            Grid.SetRow(invoer, 0);
            Grid.SetColumn(invoer, 0);
            grid.Children.Add(invoer);

            Grid.SetRow(uitvoer, 0);
            Grid.SetColumn(uitvoer, 1);
            grid.Children.Add(uitvoer);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

    }
}
