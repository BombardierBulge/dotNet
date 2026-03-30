using System.ComponentModel.DataAnnotations;

namespace WalutyAPI;

// Tabela główna
public class CurrencyRequest
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string BaseCurrency { get; set; }
    
    // Relacja: Jeden wniosek ma wiele kursów
    public List<RateValue> Rates { get; set; } = new();
}

// Tabela szczegółowa (Relacja 1:N)
public class RateValue
{
    public int Id { get; set; }
    public string CurrencyCode { get; set; }
    public decimal Value { get; set; }
    
    public int CurrencyRequestId { get; set; }
}