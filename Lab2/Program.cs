using ProblemPlecakowy;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj ilość przedmiotów:");
            int n = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Podaj seed:");
            int seed = int.Parse(Console.ReadLine() ?? "0");
            Problem problem = new Problem(n, seed);
            Console.WriteLine(problem);
            Console.WriteLine("Podaj rozmiar plecaka:");
            int rozmiar = int.Parse(Console.ReadLine() ?? "0");
            var wynik = problem.Rozwiaz(rozmiar);
            Console.WriteLine(wynik);
        }
    }
}