using SorteerBestanden;
using Sorteren;
using System;
using System.Windows;
using Microsoft.Win32;

namespace SorteerProgramma
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

        private void BtnInput_Click(object sender, RoutedEventArgs e)
        {
            TxtInputFile.Text = BrowseFile();
        }

        private void BtnOutput_Click(object sender, RoutedEventArgs e)
        {
            TxtOutputFile.Text = BrowseFile();
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TypeSchool.IsChecked == true)
                {
                    BestandSorteerder<School> bs = null;
                    SchoolSorteerder vergelijker = new SchoolSorteerder();
                    if (SortSelection.IsChecked.Value)
                    {
                        bs = new BestandSorteerder<School>(SorteerBib<School>.SelectieSorteer, SchoolLezer.LeesSchool, vergelijker);
                    }
                    else if (SortBubble.IsChecked == true){
                        bs = new BestandSorteerder<School>(SorteerBib<School>.BubbleSorteer, SchoolLezer.LeesSchool, vergelijker);
                    }
                    bs.Parse(TxtInputFile.Text, TxtOutputFile.Text);
                    TxtResult.Text = "Scholen gesorteerd";
                }
                else if (TypePark.IsChecked == true)
                {
                    BestandSorteerder<Park> bs = null;
                    ParkSorteerder vergelijker = new ParkSorteerder();
                    if (SortSelection.IsChecked.Value)
                    {
                        bs = new BestandSorteerder<Park>(SorteerBib<Park>.SelectieSorteer, ParkLezer.LeesPark, vergelijker);
                    }
                    else if (SortBubble.IsChecked == true)
                    {
                        bs = new BestandSorteerder<Park>(SorteerBib<Park>.BubbleSorteer, ParkLezer.LeesPark, vergelijker);
                    }
                    bs.Parse(TxtInputFile.Text, TxtOutputFile.Text);
                    TxtResult.Text = "Parken gesorteerd";
                }
            }
            catch(Exception exception)
            {
                TxtResult.Text = exception.Message;
            }
        }

        private string BrowseFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV files (*.csv)|*.csv|TXT Files (*.txt)|*.txt";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                return dlg.FileName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
