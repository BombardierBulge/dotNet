using System.Text;

namespace ProblemPlecakowy
{
    public class Przedmiot
    {
        public int Id ;
        public int Wartosc;
        public int Waga;
        
        public double Stosunek => (double)Wartosc / Waga;

        public override string ToString()
        {
            return $"no.:{Id} $:{Wartosc} w:{Waga}";
        }
    }
}