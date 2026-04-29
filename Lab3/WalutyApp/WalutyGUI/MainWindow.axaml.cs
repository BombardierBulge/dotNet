using System;
using System.Collections.Generic; 
using System.Linq;                
using System.Threading.Tasks;  
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using WalutyGUI;

namespace WalutyGUI;

public partial class MainWindow : Window
{
    private readonly CurrencyService _service = new();
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OnGetRatesClick(object sender, RoutedEventArgs e)
    {
        string date = DateInput.Text ?? "";
        
        if (string.IsNullOrWhiteSpace(date))
        {
            StatusLabel.Text = "Błąd: Wpisz datę!";
            return;
        }

        StatusLabel.Text = "Pracuję...";
        RatesList.ItemsSource = null;

        try
        {
            using var db = new AppDbContext();
            //tworzymy baze
            db.Database.EnsureCreated();

            //szukamy czy mamy już dane dla tej daty w bazie
            var cached = db.CurrencyRequests
                           .Include(r => r.Rates)
                           .FirstOrDefault(r => r.Date == date);

            if (cached != null)
            {
                StatusLabel.Text = "Dane z bazy lokalnej (SQLite).";
                RatesList.ItemsSource = cached.Rates;
            }
            else
            {
                StatusLabel.Text = "Brak w bazie. Pobieram z API...";
                var apiData = await _service.GetHistoricalRatesAsync(date);

                if (apiData != null && apiData.Rates != null)
                {
                    // wczytujemy z API do bazy danych
                    var newRecord = new CurrencyRequest
                    {
                        Date = date,
                        BaseCurrency = apiData.BaseCurrency,
                        Rates = apiData.Rates.Select(kv => new RateValue 
                        { 
                            CurrencyCode = kv.Key, 
                            Value = kv.Value 
                        }).ToList()
                    };

                    //zapisanie w bazie
                    db.CurrencyRequests.Add(newRecord);
                    await db.SaveChangesAsync();

                    StatusLabel.Text = "Dane pobrane z API i zapisane do bazy.";
                    // wyświetlenie kursów
                    RatesList.ItemsSource = newRecord.Rates;
                }
                else
                {
                    StatusLabel.Text = "Błąd: API zwróciło puste dane.";
                }
            }
        }
        catch (Exception ex)
        {
            //błędowanie
            StatusLabel.Text = $"Błąd: {ex.Message}";
            Console.WriteLine(ex.ToString());
        }
    }
}