using System.Windows.Controls;
using System;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for InvoerControl.xaml
    /// </summary>
    public partial class InvoerControl : UserControl, IObserver
    {
        DrukPascal model;
        public InvoerControl(DrukPascal model)
        {
            InitializeComponent();
            this.model = model;
            lblEenheid.Content = model.Eenheid;
            groupBox.Header = "druk in " + model.Naam;
            model.AddObserver(this);
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

        public void Update()
        {
            txtWaarde.Text = Convert.ToString(model.Druk);
            txtMax.Text = Convert.ToString(model.Max);
        }
    }
}
