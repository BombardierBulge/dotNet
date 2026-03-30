using System.Net.Http.Json;

namespace WalutyAPI
{
    public class CurrencyService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string AppId = Environment.GetEnvironmentVariable("OPEN_EXCHANGE_RATES_APP_ID");        
        public async Task<ExchangeRateResponse> GetHistoricalRatesAsync(string date)
        {

            // format daty: YYYY-MM-DD
            string url = $"https://openexchangerates.org/api/historical/{date}.json?app_id={AppId}";

            var response = await _client.GetFromJsonAsync<ExchangeRateResponse>(url);
            return response;
        }
    }
    
}