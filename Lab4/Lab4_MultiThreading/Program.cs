using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class Matrix
{
    private double[,] data;
    public int Size { get; }

    public Matrix(int size)
    {
        Size = size;
        data = new double[size, size];
    }

    public void FillRandom()
    {
        Random rand = new Random();
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                data[i, j] = rand.NextDouble() * 10;
    }


    public void Print()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
                Console.Write($"{data[i, j]:F2} ");
            Console.WriteLine();
        }
    }

    public static Matrix MultiplyParallel(Matrix A, Matrix B, int threadCount)
    {
        int n = A.Size;
        Matrix result = new Matrix(n);

        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = threadCount
        };

        Parallel.For(0, n, options, i =>
        {
            for (int j = 0; j < n; j++)
            {
                double sum = 0;
                for (int k = 0; k < n; k++)
                {
                    sum += A.data[i, k] * B.data[k, j];
                }
                result.data[i, j] = sum;
            }
        });

        return result;
    }
    public static Matrix MultiplyLowLevel(Matrix A, Matrix B, int threadCount)
    {
        int n = A.Size;
        Matrix result = new Matrix(n);
        Thread[] threads = new Thread[threadCount];
        int rowsPerThread = n / threadCount;

        for (int i = 0; i < threadCount; i++)
        {
            int startRow = i * rowsPerThread;
            // Ostatni wątek bierze resztę wierszy, jeśli podział nie jest równy
            int endRow = (i == threadCount - 1) ? n : (i + 1) * rowsPerThread;

            threads[i] = new Thread(() =>
            {
                for (int row = startRow; row < endRow; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        double sum = 0;
                        for (int k = 0; k < n; k++)
                        {
                            sum += A.data[row, k] * B.data[k, col];
                        }
                        result.data[row, col] = sum;
                    }
                }
            });

            threads[i].Start(); 
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return result;
    }

    // W pliku Program.cs pod klasą Matrix:
    class Program
{
    static void Main(string[] args)
    {
        int size = 1000; 
        int[] threadConfigs = { 1, 2, 4, 8, 12, 16 }; 
        int iterations = 3;

        Matrix m1 = new Matrix(size);
        Matrix m2 = new Matrix(size);
        m1.FillRandom();
        m2.FillRandom();

        // Rozgrzewka (Warm-up) - ignorujemy te wyniki
        Matrix.MultiplyParallel(m1, m2, 1);

        Console.WriteLine($"Mnożenie macierzy {size}x{size}");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("| Wątki | Parallel (ms) | Thread (ms) | Przyspieszenie |");
        Console.WriteLine("---------------------------------------------------------");

        long timeBase = 0;

        foreach (int threads in threadConfigs)
        {
            // Pomiar dla Parallel
            Stopwatch swP = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++) Matrix.MultiplyParallel(m1, m2, threads);
            swP.Stop();
            long avgParallel = swP.ElapsedMilliseconds / iterations;

            // Pomiar dla Thread (niskopoziomowo)
            Stopwatch swT = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++) Matrix.MultiplyLowLevel(m1, m2, threads);
            swT.Stop();
            long avgThread = swT.ElapsedMilliseconds / iterations;

            // Obliczanie przyspieszenia względem 1 wątku (dla Parallel)
            if (threads == 1) timeBase = avgParallel;
            double speedup = (double)timeBase / avgParallel;

            Console.WriteLine($"| {threads,5} | {avgParallel,13} | {avgThread,11} | {speedup,13:F2}x |");
        }
        Console.WriteLine("---------------------------------------------------------");
    }
}


}