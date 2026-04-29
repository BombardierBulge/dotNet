# Lab4_MultiThreading

## Opis projektu

Ten program demonstruje mnożenie macierzy kwadratowych przy użyciu różnych podejść wielowątkowych w języku C#. Porównuje wydajność między:

- **Parallel.For** z biblioteki TPL (.NET Task Parallel Library)
- **Niskopoziomowymi wątkami** (Thread class)

Program mierzy czas wykonania dla różnych liczb wątków (1, 2, 4, 8, 12, 16) i oblicza przyspieszenie względem wykonania jednowątkowego.

## Wymagania

- .NET 10.0 lub nowszy
- System operacyjny: Windows, Linux lub macOS

## Jak uruchomić

1. Przejdź do katalogu projektu:
   ```
   cd Lab4/Lab4_MultiThreading
   ```

2. Przywróć zależności (jeśli potrzebne):
   ```
   dotnet restore
   ```

3. Uruchom program:
   ```
   dotnet run
   ```

## Jak używać

Program automatycznie:
- Tworzy dwie losowe macierze 1000x1000
- Wykonuje mnożenie macierzy dla każdej konfiguracji wątków
- Mierzy czas wykonania (średnia z 3 iteracji)
- Wyświetla wyniki w tabeli

Parametry można modyfikować w kodzie źródłowym:
- `size`: rozmiar macierzy (domyślnie 1000)
- `threadConfigs`: lista liczb wątków do przetestowania
- `iterations`: liczba iteracji dla uśrednienia czasu

## Wyniki

Program wyświetla tabelę z wynikami zawierającą:
- Liczbę wątków
- Średni czas wykonania dla Parallel.For (w ms)
- Średni czas wykonania dla niskopoziomowych wątków (w ms)
- Przyspieszenie względem wykonania jednowątkowego

## Uwagi

- Dla małych macierzy efekty wielowątkowości mogą być niewidoczne ze względu na narzut tworzenia wątków
- Optymalna liczba wątków zależy od liczby rdzeni procesora
- Program wykonuje "rozgrzewkę" przed pomiarami, aby uniknąć wpływu JIT kompilacji na wyniki