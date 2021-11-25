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
            ImgMan.Visibility = Visibility.Hidden;
            BtnVerbergWoord.Visibility = Visibility.Visible;
            TxtInput.Focus();
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
                ImgMan.Visibility = Visibility.Visible;
                TxtBInfo.Text = $"{levens} Levens\nJuiste letters {juistLetters}\nFoute letters {foutLetters}";
            }
        }

        public void LetterGeraden()
        {
            char[] lettersGeheimWoord = geheimeWoord.ToCharArray();
            bool letterIsInWoord = false;
            char charRaadPoging;
            bool convToChar = char.TryParse(raadPoging, out charRaadPoging);

            if (convToChar)
            {
                foreach (char c in lettersGeheimWoord)
                {
                    if (c.Equals(charRaadPoging))
                    {
                        letterIsInWoord = true;
                    }
                }
            }
            else if (!convToChar)
            {
                MessageBox.Show("Geef een letter of woord in");
            }


            if (letterIsInWoord && convToChar)
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
            else if (!letterIsInWoord && convToChar)
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
            }
            else
            {
                LetterGeraden();
            }
        }

        private BitmapImage ImgSource(int imgNumber)
        {
            return new BitmapImage(new Uri($@"F:\OefeningenC#Essentials\Galgje\Galgje\Assets\{imgNumber}.jpg", UriKind.Absolute));
        }

        private void ManWordGehangen()
        {
            switch (levens)
            {
                case 10:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 9:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 8:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 7:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 6:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 5:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 4:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 3:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 2:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 1:
                    ImgMan.Source = ImgSource(levens);
                    break;
                case 0:
                    ImgMan.Source = ImgSource(levens);
                    break;
                default:
                    break;
            }
        }


        private void BtnNieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            InitSpel();
        }

        private void BtnRaad_Click(object sender, RoutedEventArgs e)
        {
            RaadPoging();
            ManWordGehangen();
            if (levens < 1)
            {
                MessageBox.Show($"Je hebt verloren\nHet juiste woord was: {geheimeWoord}");
                InitSpel();
            }
            TxtInput.Focus();
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
            TxtInput.Focus();
        }

    }
}
