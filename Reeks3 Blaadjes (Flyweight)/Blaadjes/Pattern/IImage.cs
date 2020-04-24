using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Blaadjes.Pattern
{
    public interface IImage
    {
        Image ImageObject { get; }
        Point Move(Point p);
    }
}
