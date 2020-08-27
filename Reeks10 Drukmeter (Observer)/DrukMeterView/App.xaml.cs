using DrukMeterView.DecoratorPattern;
using System.Windows;
using Unity;
using Unity.Injection;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //kies een eenheid - via drie tabellen (optioneel)
            double[] factor = { 1.0, 101325, 101325 / 14.7 };
            string[] eenheid = { "Pa", "atm", "psi" };
            string[] naam = { "Pascal", "Atmosfeer", "psi" };
            int kies = new System.Random().Next() % 3;

            //ZonderDependencyInjection(factor[kies],eenheid[kies],naam[kies]);
            Stap2(factor[kies], eenheid[kies], naam[kies]);
        }

        private void Stap1()
        {
            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<ISubject, DrukPascal>();
                ISubject model = container.Resolve<DrukPascal>();
                container.RegisterInstance(model);
                MainWindow mainWindow = container.Resolve<MainWindow>();
                mainWindow.Show();
            }
        }

        private void Stap2(double factor, string eenheid, string naam)
        {
            using(IUnityContainer container = new UnityContainer())
            {
                //willekeurige eenheid
                container.RegisterType<ISubject, DrukPascal>(); //registreer basisklasse
                container.RegisterType<DrukKlasse>(new InjectionConstructor(typeof(DrukPascal), factor, eenheid, naam));
                //unieke instance voor observer
                ISubject model = container.Resolve<DrukKlasse>();

                container.RegisterInstance(model);
                MainWindow mainWindow = container.Resolve<MainWindow>();
                mainWindow.Show();
            }
        }

        private void ZonderDependencyInjection(double factor, string eenheid, string naam)
        {
            //deel1 enkel pascal
            DrukPascal Bmodel = new DrukPascal();

            //willekeurige eenheid
            ISubject model = new DrukKlasse(Bmodel, factor, eenheid, naam);

            UitvoerControl uitvoer = new UitvoerControl(model);
            InvoerControl invoer = new InvoerControl(model);
            //zonder dependency injection  kan je hier registreren
            //model.Add(invoer.Update); //registreer Observer
            //model.Add(uitvoer.UpdateWijzer); //registreer Observer
            //model.Druk = model.Druk; //Observers worden geactiveerd

            MainWindow = new MainWindow(invoer, uitvoer);
        }
    }
}
