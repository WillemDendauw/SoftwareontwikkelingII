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
using System.Windows.Threading;
using Blaadjes.Pattern;

namespace Blaadjes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private Dictionary<IImage, IList<Point>> dict;
        private ImageFactory factory;
        public MainWindow()
        {
            InitializeComponent();
            factory = new ImageFactory();
            dict = new Dictionary<IImage, IList<Point>>();
            foreach(string soort in ImageFactory.SOORTEN)
            {
                dict.Add(factory[soort], new List<Point>());
            }

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += timerEvent;
            dispatcherTimer.Interval = new TimeSpan(1000000);
            dispatcherTimer.Start();
        }

        private void addLeaf()
        {
            IImage image = factory.KiesBlad();
            Point p = new Point(random.Next((int)Width - 20) + 10, 20);
            dict[image].Add(p);
        }

        private void addFeather()
        {
            if(random.Next(10) == 0)
            {
                int aantal = ImageFactory.SOORTEN.Count();
                string type = ImageFactory.SOORTEN[aantal - 1];

                IImage image = factory[type];
                Point p = new Point((int)Width - 50, 20);
                dict[image].Add(p);
            }
        }

        private void timerEvent(object sender, EventArgs e)
        {
            addLeaf();
            addFeather();
            canvas.Children.Clear();

            foreach (IImage image in dict.Keys)
            {
                for(int i = 0; i < dict[image].Count; i++)
                {
                    Point p = dict[image][i];
                    p = image.Move(p);
                    p.X = Math.Min(p.X, Width);
                    p.Y = Math.Min(p.Y, Height);
                    dict[image][i] = p;
                    Draw(image, p);
                }
            }
        }

        private void Draw(IImage image, Point p)
        {
            Image simpleImage = image.ImageObject;
            canvas.Children.Add(simpleImage);
            Canvas.SetLeft(simpleImage, p.X);
            Canvas.SetTop(simpleImage, p.Y);
        }
    }
}
