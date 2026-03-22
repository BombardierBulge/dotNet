using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Media;
using ProblemPlecakowy;

namespace WindowApp
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void BtnSolve_Click(object? sender, RoutedEventArgs e)
        {

            TxtN.Background = Brushes.White;


            if (int.TryParse(TxtN.Text, out int n) &&
                int.TryParse(TxtSeed.Text, out int seed) &&
                int.TryParse(TxtCapacity.Text, out int capacity))
            {

                Problem problem = new Problem(n, seed);
                Plecak wynik = problem.Rozwiaz(capacity);
                Txtwylosowane.Text = problem.ToString();

                TxtResult.Text = wynik.ToString();
            }
            else
            {
                TxtN.Background = Brushes.LightPink;
                TxtResult.Text = "Błędne dane! Wpisz liczby całkowite.";
            }
        }
    }
}