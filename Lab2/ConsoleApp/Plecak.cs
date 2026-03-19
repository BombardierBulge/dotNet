using System.Text;
namespace ProblemPlecakowy
{
    internal class Plecak
    { 
        public List<int> ListaId { set; get; } = new List<int>();
        public int CalaWartosc;
        public int CalaWaga;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Przedmioty:{string.Join(" ",ListaId)}");
            sb.AppendLine($"Waga:{string.Join(" ",CalaWaga)}");
            sb.AppendLine($"Wartosc:{string.Join(" ",CalaWartosc)}");
            return sb.ToString();
        }
    }
}