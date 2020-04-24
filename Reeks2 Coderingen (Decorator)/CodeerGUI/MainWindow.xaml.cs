using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Coderingen;
using Coderingen.Pattern;

namespace CodeerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICodering codering;
        public MainWindow()
        {
            InitializeComponent();
            codering = new BasisCodering();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Blok.IsChecked.Value)
            {
                codering = new BlokCodering(codering);
            }
            else if (Wissel.IsChecked.Value)
            {
                codering = new WisselCodering(codering);
            }
            else if (Cijfer.IsChecked.Value)
            {
                codering = new CijferCodering(codering);
            }
            uitvoer.Text = codering.Codeer(invoer.Text);
        }
    }
}
