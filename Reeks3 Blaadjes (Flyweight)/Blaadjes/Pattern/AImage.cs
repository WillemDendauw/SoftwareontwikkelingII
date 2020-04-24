using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Blaadjes.Pattern
{
    public abstract class AImage : IImage
    {
        private BitmapImage bitMap;
        protected double w, h;

        public AImage(string bestandsnaam)
        {
            bitMap = new BitmapImage(new Uri(bestandsnaam, UriKind.RelativeOrAbsolute));
            h = 25;
            w = 25;
        }

        public Image ImageObject
        {
            get
            {
                Image simpleImage = new Image();
                simpleImage.Width = w;
                simpleImage.Height = h;
                simpleImage.Source = bitMap;
                return simpleImage;
            }
        }

        public abstract Point Move(Point p);
    }
}
