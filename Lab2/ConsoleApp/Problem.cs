using System.Data.Common;
using ProblemPlecakowy;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestinngApp")]


namespace ProblemPlecakowy
{
    
    internal class Problem
    {
        public int N ; // ilosc przedmiotów w placaku
        public List<Przedmiot> Przedmioty;

        public Problem(int n, int seed)
        {
            N = n;
            Przedmioty = new List<Przedmiot>();
            Random random = new Random(seed);

            for(int i= 0; i < N; i++)
            {
                Przedmioty.Add(new Przedmiot{
                    Id = i,
                    Wartosc = random.Next(1,10),
                    Waga = random.Next(1,10)
                });

            }
        
        }
        public Plecak Rozwiaz(int rozmiar)
        {
            Plecak wynik = new Plecak();
            var posortowanePrzedmioty = Przedmioty.OrderByDescending(x => x.Stosunek).ToList();
            foreach (var przedmiot in posortowanePrzedmioty)
            {
                if(wynik.CalaWaga + przedmiot.Waga <= rozmiar)
                {
                    wynik.ListaId.Add(przedmiot.Id);
                    wynik.CalaWaga+= przedmiot.Waga;
                    wynik.CalaWartosc += przedmiot.Wartosc;

                }
            }

            return wynik;
        }
        public override string ToString()
        {
           
            return string.Join(Environment.NewLine, Przedmioty.Select(x => x.ToString()));
        }

    }
}