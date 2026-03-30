using WalutyAPI;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();
CurrencyService service = new CurrencyService();

using var db = new AppDbContext();
db.Database.EnsureCreated();

Console.WriteLine("/////////////// Pobieranie kursów walut (Open Exchange Rates) ///////////////");
Console.Write("Podaj datę dla kursów historycznych (format RRRR-MM-DD, np. 2023-01-01): ");
string date = Console.ReadLine() ?? "";

try
{
    var cachedRequest = db.CurrencyRequests
    .Include(r => r.Rates)
    .FirstOrDefault(r => r.Date == date);

    if (cachedRequest != null)
    {
        Console.WriteLine("Dane znalezione w bazie danych (cache):");
        Console.WriteLine($"Data: {cachedRequest.Date}");
        Console.WriteLine($"Waluta bazowa: {cachedRequest.BaseCurrency}");
        Console.WriteLine($"Liczba kursów: {cachedRequest.Rates.Count}");
        Console.WriteLine("Przykładowe kursy:");
        foreach (var rate in cachedRequest.Rates.Take(10))
        {
            Console.WriteLine($"{rate.CurrencyCode}: {rate.Value}");
        }
    }
    else
    {

        Console.WriteLine("Brak danych w bazie danych. Pobieranie danych...");

        ExchangeRateResponse data = await service.GetHistoricalRatesAsync(date);

        if (data != null)
        {
            // Zapis do bazy danych
            var newRecord = new CurrencyRequest
            {
                Date = date,
                BaseCurrency = data.BaseCurrency,
                Rates = data.Rates.Select(r => new RateValue
                {
                    CurrencyCode = r.Key,
                    Value = r.Value
                }).ToList()
            };
            db.CurrencyRequests.Add(newRecord);
            await db.SaveChangesAsync();

            Console.WriteLine("Dane zostały zapisane do bazy danych.");
        }

        if (data != null && data.Rates != null)
        {
            Console.WriteLine($"\nWynik dla daty: {date}");
            Console.WriteLine($"Waluta bazowa: {data.BaseCurrency}");
            Console.WriteLine("Przykładowe kursy:");
            Console.WriteLine($"///////////////////////////////////\nLiczba dostępnych kursów: {data.Rates.Count()}\n///////////////////////////////////");
            int przyklad = 10;
            Console.WriteLine($"{przyklad} pierwszych kursów: ");
            foreach (var rate in data.Rates.Take(przyklad))
            {
                Console.WriteLine($"{rate.Key}: {rate.Value}");
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
}

Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
Console.ReadKey();