using System.Text.Json.Serialization;

namespace WalutyAPI
{
    // Główny obiekt odpowiedzi z API
    public class ExchangeRateResponse
    {
        [JsonPropertyName("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonPropertyName("license")]
        public string License { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("base")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, decimal> Rates { get; set; }

        public override string ToString()
        {
            return $"Baza: {BaseCurrency}, Liczba kursów: {Rates?.Count ?? 0}";
        }
    }
}