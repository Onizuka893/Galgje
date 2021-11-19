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

namespace Galgje
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

        public string raadWoord;
        public string foutLetters;
        public string juistLetters;
        public int levens;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitSpel();
        }

        public void InitSpel()
        {
            TxtBInfo.Text = "Geef een geheim woord in:";
            TxtInput.Clear();
            BtnNieuwSpel.IsEnabled = true;
            BtnRaad.IsEnabled = true;
            BtnVerbergWoord.IsEnabled = true;
            BtnVerbergWoord.Visibility = Visibility.Visible;
            levens = 10;
            juistLetters = "";
            foutLetters = "";
        }

        public void RaadStatus()
        {
            if (TxtInput.Text == "")
            {
                MessageBox.Show("Vul een Woord in om het spel te beginnen!");
            }
            else
            {
                raadWoord = TxtInput.Text.ToLower();
                TxtInput.Clear();
                BtnVerbergWoord.Visibility = Visibility.Hidden;
                TxtBInfo.Text = $"{levens} Levens\nJuiste letters {juistLetters}\nFoute letters {foutLetters}";
            }
        }

        public void LetterOfWoord()
        {
            int lengteInput = TxtInput.Text.Length;
        }

        public void RaadPoging()
        {
            if (TxtInput.Text != raadWoord)
            {
                --levens;
                if (foutLetters == "")
                {
                    foutLetters += $"{TxtInput.Text}";
                }
                else
                {
                    foutLetters += $",{TxtInput.Text}";
                }
                TxtInput.Clear();
                TxtBInfo.Text = $"{levens} Levens\nJuiste letters {juistLetters}\nFoute letters {foutLetters}";
            }
            else if (TxtInput.Text == raadWoord)
            {
                MessageBox.Show("Gefeliciteerd!\nje hebt juist geraden");
                InitSpel();
            }
            if (levens < 1)
            {
                MessageBox.Show("Je hebt verloren");
                InitSpel();
            }
        }



        private void BtnNieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            InitSpel();
        }

        private void BtnRaad_Click(object sender, RoutedEventArgs e)
        {
            RaadPoging();
        }

        private void BtnVerbergWoord_Click(object sender, RoutedEventArgs e)
        {
            RaadStatus();
        }

    }
}
