# MojaAplikacjaBlazor

Aplikacja Blazor Server / Interactive Components wykorzystująca ML.NET do analizy nastroju tekstu.

## Opis

Projekt zawiera prostą aplikację webową napisaną w .NET 10.0 z użyciem Blazor Interactive Server. Główną funkcjonalnością jest strona analizy nastroju (`Sentiment`), która wykorzystuje wczytany model ML.NET z pliku `MLModel.zip` do przewidywania `Prediction` na podstawie wprowadzonego tekstu.

## Główne funkcje

- strona `Sentiment` do analizy nastroju tekstu
- model ML.NET ładowany z pliku `MLModel.zip`
- prosta nawigacja Blazor z domyślnymi stronami `Home`, `Counter` i `Weather`
- interaktywne komponenty Blazor Server

## Wymagania

- .NET SDK 10.0
- `MLModel.zip` w katalogu projektu (plik z wytrenowanym modelem)

## Uruchamianie

1. Otwórz terminal w katalogu projektu:
   ```bash
   cd /home/bocian/Projects/dotNET/dotNet/Lab5/MojaAplikacjaBlazor
   ```
2. Uruchom aplikację:
   ```bash
   dotnet run
   ```
3. Otwórz przeglądarkę i przejdź do adresu wyświetlonego w konsoli.

## Struktura projektu

- `Program.cs` - konfiguracja hosta, usług ML.NET i Blazor Interactive Server
- `MojaAplikacjaBlazor.csproj` - definicja projektu
- `MLModel.zip` - wytrenowany model ML.NET używany do prognozowania
- `ModelInput.cs` / `ModelOutput.cs` - klasy wejścia i wyjścia modelu wygenerowane przez ML.NET CLI
- `Components/Pages/Sentiment.razor` - komponent do analizy nastroju
- `train.csv` - dane treningowe użyte do tworzenia modelu

## Jak działa strona Sentiment

Użytkownik wpisuje tekst w polu tekstowym, a po kliknięciu przycisku `Analizuj nastrój` aplikacja tworzy obiekt `ModelInput` z właściwością `Text`, a następnie używa `PredictionEnginePool` do wykonania przewidywania. Wynik jest wyświetlany w sekcji `Wynik analizy`.

## Uwagi

- Aplikacja zakłada, że model ML.NET obsługuje kolumnę `Text` jako dane wejściowe.
- Jeśli chcesz zmodyfikować lub przetrenować model, skorzystaj z pliku `train.csv` i narzędzi ML.NET CLI.
