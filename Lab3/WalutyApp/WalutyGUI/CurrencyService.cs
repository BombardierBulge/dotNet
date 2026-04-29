using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace WalutyGUI
{
    public class CurrencyService
{
    private readonly HttpClient _client = new HttpClient();
    
    // TEJ LINII CI BRAKOWAŁO (deklaracja pola klasy):
    private readonly string? _appId = Environment.GetEnvironmentVariable("OPEN_EXCHANGE_RATES_APP_ID");

    public async Task<ExchangeRateResponse?> GetHistoricalRatesAsync(string date)
    {
        // Sprawdzenie czy klucz został wczytany
        if (string.IsNullOrEmpty(_appId))
        {
            throw new Exception("Błąd: Klucz API (OPEN_EXCHANGE_APP_ID) nie został znaleziony w systemie!");
        }

        string url = $"https://openexchangerates.org/api/historical/{date}.json?app_id={_appId}";
        
        // Pobranie danych
        var response = await _client.GetFromJsonAsync<ExchangeRateResponse>(url);
        return response;
    }
}
    
}