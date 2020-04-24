using Microsoft.Win32;
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

namespace ImageViewer
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image Files(*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif";

            if (dlg.ShowDialog().Value)
            {
                string filename = dlg.FileName;
                string[] words = filename.Split('\\');
                BestandsNaam.Text = words[words.Length - 1];

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                Image.Source = bi;

                ImageRotateTransform.Angle = 0;
                ButtonLinks.IsEnabled = true;
                ButtonRechts.IsEnabled = true;
            }
        }

        private void Button_links(object sender, RoutedEventArgs e)
        {
            Rotate(-90);
        }

        private void Button_rechts(object sender, RoutedEventArgs e)
        {
            Rotate(90);
        }

        private void Rotate(double hoek)
        {
            ImageRotateTransform.Angle += hoek;
        }
    }
}
