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

namespace KolkoKrzyzyk
{

    public partial class MainWindow : Window
    {

        private ServiceKolkoKrzyzyk.GraKolkoKrzyzykClient game;

        public MainWindow()
        {
            InitializeComponent();

            this.game = new ServiceKolkoKrzyzyk.GraKolkoKrzyzykClient();
            game.Start();

            ResultLabel.Content = "";
        }

        private void Newgame_click(object sender, RoutedEventArgs e)
        {
            game.Start();

            Button0.Content = "";
            Button1.Content = "";
            Button2.Content = "";
            Button3.Content = "";
            Button4.Content = "";
            Button5.Content = "";
            Button6.Content = "";
            Button7.Content = "";
            Button8.Content = "";

            Button0.IsEnabled = true;
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;

            ResultLabel.Content = "Nowa Gra";
        }

        private void MarkNought(int w, int k)
        {
            int indeks = w * 3 + k;

            switch (indeks)
            {
                case 0:
                    Button0.Content = "O";
                    break;

                case 1:
                    Button1.Content = "O";
                    break;

                case 2:
                    Button2.Content = "O";
                    break;

                case 3:
                    Button3.Content = "O";
                    break;

                case 4:
                    Button4.Content = "O";
                    break;

                case 5:
                    Button5.Content = "O";
                    break;

                case 6:
                    Button6.Content = "O";
                    break;

                case 7:
                    Button7.Content = "O";
                    break;

                case 8:
                    Button8.Content = "O";
                    break;

                default:
                    break;
            }

            ResultLabel.Content = ResultLabel.Content +
                "Ruch Przeciwnika: " + w + ", " + k;

        }

        private void ZakonczGre()
        {
            Button0.IsEnabled = false;
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            Button5.IsEnabled = false;
            Button6.IsEnabled = false;
            Button7.IsEnabled = false;
            Button8.IsEnabled = false;
        }

        private void CheckEnd(int rc, int wc, int ro, int co)
        {
            if (game.CheckVictory(rc, wc) != 0)
            {
                ResultLabel.Content = "Krzyżyk Wygrywa!";
                ZakonczGre();
            }
            if (ro == 3 && co == 3) return;
            if (game.CheckVictory(ro, co) != 0)
            {
                ResultLabel.Content = "Kółko Wygrywa!";
                ZakonczGre();
            }
            if (game.CheckVictory(ro, co) != 0 && game.CheckVictory(rc, wc) != 0)
            {
                ResultLabel.Content = "Remis!";
                ZakonczGre();
            }
        }

        private void Buttonclick(int row, int column, object sender)
        {
            if (game.MakeMove(row, column, out int r, out int c))
            {
                ResultLabel.Content = "Twój ruch: " + row + ", " + column + " ";
                (sender as Button).Content = "X";
                MarkNought(r, c);
                CheckEnd(row, column, r, c);
            }
            else
            {
                ResultLabel.Content = "Niepoprawny ruch";
            }
        }

        private void Button0_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(0, 0, sender);
        }

        private void Button1_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(0, 1, sender);
        }

        private void Button2_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(0, 2, sender);
        }

        private void Button3_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(1, 0, sender);
        }

        private void Button4_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(1, 1, sender);
        }

        private void Button5_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(1, 2, sender);
        }

        private void Button6_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(2, 0, sender);
        }

        private void Button7_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(2, 1, sender);
        }

        private void Button8_click(object sender, RoutedEventArgs e)
        {
            Buttonclick(2, 2, sender);
        }
    }
}
