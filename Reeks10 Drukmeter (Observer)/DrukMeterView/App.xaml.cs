using System.Windows;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DrukPascal model = new DrukPascal();
            //// Pascal zonder DI
            InvoerControl invoer = new InvoerControl(model);
            UitvoerControl uitvoer = new UitvoerControl(model);
            MainWindow mainWindow = new MainWindow(invoer, uitvoer);
            mainWindow.Show();
        }
    }
}
