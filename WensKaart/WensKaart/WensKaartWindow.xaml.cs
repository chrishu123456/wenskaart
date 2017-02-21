using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (StylusPointPropertyInfo info in typeof(Colors).GetProperties())
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
                cirkelsKleuren.Items.Add(kleurke);
                rechthoekenKleuren.Items.Add(kleurke);
                cirkelKaderKleuren.Items.Add(kleurke);
                rechthoekKaderKleuren.Items.Add(kleurke);
            }
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
            cirkelsKleuren.Items.Add(kleurke);
            rechthoekenKleuren.Items.Add(kleurke);
            cirkelKaderKleuren.Items.Add(kleurke);
            rechthoekKaderKleuren.Items.Add(kleurke);
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(grootteText.Content);
            if (aantal < 40)
            { aantal++; }
            grootteText.Content = aantal.ToString();
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int aantal = Convert.ToInt16(grootteText.Content);
            if (aantal > 10)
            { aantal--; }
            grootteText.Content = aantal.ToString();
        }
    }
}
