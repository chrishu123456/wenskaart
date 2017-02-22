using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace WensKaart
{
    /// <summary>
    /// Interaction logic for WensKaartWindow.xaml
    /// </summary>
    public partial class WensKaartWindow : Window
    {
        public WensKaartWindow()
        {
            InitializeComponent();

            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur =
    (SolidColorBrush)bc.ConvertFromString(info.Name);
                Kleur kleurke = new Kleur();
                kleurke.Borstel = deKleur;
                kleurke.Naam = info.Name;
                kleurke.Hex = deKleur.ToString();
                kleurke.Rood = deKleur.Color.R;
                kleurke.Groen = deKleur.Color.G;
                kleurke.Blauw = deKleur.Color.B;
                balKleuren.Items.Add(kleurke);
              
            }
 
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(grootteText.Content);
            if (aantal < 40)
            {
                aantal++;
                Wens.FontSize++;
            }
            grootteText.Content = aantal.ToString();
            SaveEnAfdruk(true);
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(grootteText.Content);
            if (aantal > 10)
            {
                aantal--;
                Wens.FontSize--;
            }
            grootteText.Content = aantal.ToString();
            SaveEnAfdruk(true);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lettertypesCombobox.Items.SortDescriptions.Add(new SortDescription("Source", ListSortDirection.Ascending));
            lettertypesCombobox.SelectedItem = new FontFamily(Wens.FontFamily.ToString());
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Wenskaarten | *.wens";
                dlg.FileName = "Wenskaart";
                dlg.DefaultExt = ".wens";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        
                        string canvasbackground = @"H:\wenskaart\WensKaart\WensKaart\Images\geboortekaart.jpg";
                        bestand.WriteLine(canvasbackground);
                        bestand.WriteLine(Wens.Text.ToString());
                        bestand.WriteLine(Wens.FontFamily.ToString());
                        bestand.WriteLine(Wens.FontSize.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets fout bij het saven" + ex.Message, "Foutmelding", MessageBoxButton.OK);
            }

        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
           
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Wenskaarten | *.wens";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        string canvasbackground;
                        canvasbackground = bestand.ReadLine();
                        Wens.Text = bestand.ReadLine();
                        Wens.FontFamily = new FontFamily(bestand.ReadLine());
                        Wens.FontSize = Convert.ToDouble(bestand.ReadLine());
                    }
                    StatusItem.Content = dlg.FileName;
                    SaveEnAfdruk(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets fout bij het Openen" + ex.Message, "Foutmelding", MessageBoxButton.OK);
            }
            
        }
        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Wilt u het programma sluiten ?","Afsluiten",MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.No) == MessageBoxResult.Yes)
            { this.Close(); }
        }

        private void Nieuw()
        {
            StatusItem.Content = "Nieuw";
            SaveEnAfdruk(false);
            Wens.Text = string.Empty;
            Wens.FontSize = 10;
        }

        private void SaveEnAfdruk(Boolean actief)
        {
            Save.IsEnabled = actief;
            PrintPreview.IsEnabled = actief;
        }

        private void ChristmasCard_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BirthDayCard_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
