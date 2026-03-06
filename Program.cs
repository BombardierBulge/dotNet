using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj zakes liczb:");

            if (int.TryParse(Console.ReadLine(), out int zakres))
            {
                FizzBuzz fb = new FizzBuzz(zakres);
                fb.Wypisz();
            }
            else
            {
                Console.WriteLine("Żle wprowadzony zakres");
            }


        }
    }

    class FizzBuzz
    {
        private int _gornyZakres;
        public FizzBuzz(int zakres)
        {
            _gornyZakres = zakres;
        }
        public void Wypisz()
        {
            for (int num = 1; num <= _gornyZakres; num++)
            {
                if (num % 3 == 0 && num % 5 == 0)
                {
                    Console.Write("fizzbuzz\n");
                }
                else if (num % 3 == 0)
                {
                    Console.Write("fizz\n");
                }
                else if (num % 5 == 0)
                {
                    Console.Write("buzz\n");
                }
                else
                {
                    Console.Write($"{num}\n");
                }

            }
        }
    }
}