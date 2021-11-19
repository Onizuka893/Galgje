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

        public string geheimeWoord;
        public string raadPoging;
        public string foutLetters;
        public string juistLetters;
        public int levens;
        public bool spelBegonnen;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitSpel();
        }

        public void InitSpel()
        {
            TxtBInfo.Text = "Geef een geheim woord in:";
            TxtInput.Clear();
            BtnRaad.Visibility = Visibility.Hidden;
            BtnNieuwSpel.Visibility = Visibility.Hidden;
            BtnVerbergWoord.Visibility = Visibility.Visible;
            levens = 10;
            geheimeWoord = string.Empty;
            juistLetters = string.Empty;
            foutLetters = string.Empty;
        }

        public void RaadStatus()
        {
            if (TxtInput.Text == "")
            {
                MessageBox.Show("Vul een Woord in om het spel te beginnen!");
            }
            else
            {
                geheimeWoord = TxtInput.Text.ToLower();
                TxtInput.Clear();
                BtnVerbergWoord.Visibility = Visibility.Hidden;
                TxtBInfo.Text = $"{levens} Levens\nJuiste letters {juistLetters}\nFoute letters {foutLetters}";
            }
        }

        public void LetterGeraden()
        {
            char[] lettersGeheimWoord = geheimeWoord.ToCharArray();
            bool letterIsInWoord = false;


            foreach (char c in lettersGeheimWoord)
            {
                //hier geeft de app een error als de user geen input voert in het textbox
                if (c.Equals(Convert.ToChar(raadPoging)))
                {
                    letterIsInWoord = true;
                }
            }

            if (letterIsInWoord)
            {
                if (juistLetters == "")
                {
                    juistLetters += $"{raadPoging}";
                }
                else
                {
                    juistLetters += $",{raadPoging}";
                }
                TxtInput.Clear();
                TxtBInfo.Text = $"{levens} Levens\nJuiste letters {juistLetters}\nFoute letters {foutLetters}";
            }
            else
            {
                --levens;
                if (foutLetters == "")
                {
                    foutLetters += $"{raadPoging}";
                }
                else
                {
                    foutLetters += $",{raadPoging}";
                }
                TxtInput.Clear();
                TxtBInfo.Text = $"{levens} Levens\nJuiste letters {juistLetters}\nFoute letters {foutLetters}";
            }
        }

        public void RaadPoging()
        {
            raadPoging = TxtInput.Text;

            if (raadPoging.Length > 1)
            {
                if (raadPoging != geheimeWoord)
                {
                    --levens;
                    if (foutLetters == "")
                    {
                        foutLetters += $"{raadPoging}";
                    }
                    else
                    {
                        foutLetters += $",{raadPoging}";
                    }
                    TxtInput.Clear();
                    TxtBInfo.Text = $"{levens} Levens\nJuiste letters {juistLetters}\nFoute letters {foutLetters}";
                }
                else if (raadPoging == geheimeWoord)
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
            else
            {
                LetterGeraden();
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
            if (TxtInput.Text.Length > 1)
            {
                RaadStatus();
                BtnRaad.Visibility = Visibility.Visible;
                BtnNieuwSpel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Vul een woord in om het spel te beginnen");
            }
        }

    }
}
