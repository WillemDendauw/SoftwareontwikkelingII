using System.Windows.Controls;
using System;
using DrukMeterView.DecoratorPattern;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for InvoerControl.xaml
    /// </summary>
    public partial class InvoerControl : UserControl
    {
        ISubject model;
        public InvoerControl(ISubject model)
        {
            InitializeComponent();
            this.model = model;
            lblEenheid.Content = model.Eenheid;
            groupBox.Header = "druk in " + model.Naam;
            model.Add(Update); //kan enkel hier bij Dependency Injection
            model.Druk = model.Druk; //activeert de Notify
        }

        private void btnVerlaag_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            model.Druk--;
            //aanvullen
        }

        private void btnVerhoog_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            model.Druk++;
            //aanvullen
        }

        private void txtWaarde_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                model.Druk = double.Parse(txtWaarde.Text);
                //aanvullen
            }
        }

        public void Update(double druk, double max)
        {
            txtWaarde.Text = Convert.ToString(druk);
            txtMax.Text = Convert.ToString(max);
        }
    }
}
