using System;
using System.Windows.Controls;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for UitvoerControl.xaml
    /// </summary>
    public partial class UitvoerControl : UserControl,IObserver
    {
        DrukPascal model;
        public UitvoerControl(DrukPascal model)
        {
            InitializeComponent();
            this.model = model;
            model.AddObserver(this);
        }

        public void Update()
        {
            //pull: informatie wordt opgehaald van model
            double currentAngle = (5.0 / 4.0) * Math.PI - (model.Druk / model.Max) * (Math.PI * 3.0 / 2.0);
            wijzer.X2 = 100 + 60 * Math.Cos(currentAngle);
            wijzer.Y2 = 100 - 60 * Math.Sin(currentAngle);
        }
    }
}