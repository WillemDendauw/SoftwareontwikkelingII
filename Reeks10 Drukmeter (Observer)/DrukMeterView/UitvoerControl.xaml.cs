using DrukMeterView.DecoratorPattern;
using System;
using System.Windows.Controls;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for UitvoerControl.xaml
    /// </summary>
    public partial class UitvoerControl : UserControl
    {
        public UitvoerControl(ISubject model)
        {
            InitializeComponent();
            model.Add(UpdateWijzer); //kan enkel hier bij dependency injection
            model.Druk = model.Druk; //activeert de notify
        }

        public void UpdateWijzer(double druk, double maxDruk)
        {
            double currentAngle = (5.0 / 4.0) * Math.PI - (druk / maxDruk) * (Math.PI * 3.0 / 2.0);
            wijzer.X2 = 100 + 60 * Math.Cos(currentAngle);
            wijzer.Y2 = 100 - 60 * Math.Sin(currentAngle);
        }
    }
}