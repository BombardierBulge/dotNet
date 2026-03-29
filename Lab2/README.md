# Lab2 - Problem plecakowy (Knapsack)

Projekt `Lab2` to prosta implementacja algorytmu zachłannego dla problemu plecakowego w .NET 10.

## Struktura projektu

- `ConsoleApp/` - aplikacja konsolowa. Główny punkt wejścia `Program.cs`.
- `ConsoleApp/Problem.cs` - model problemu, generator losowy przedmiotów i metoda `Rozwiaz` do optymalizacji.
- `ConsoleApp/Plecak.cs` - model wyniku (zawiera listę wybranych ID, wagę i wartość).
- `ConsoleApp/Przedmiot.cs` - model przedmiotu, determinacja stosunku `Wartosc/Waga`.
- `WindowApp/` - wersja z interfejsem graficznym (Avalonia, w innych zadaniach).
- `TestinngApp/` - projekt testowy (MSTest) dla klasy `Problem`.

## Jak działa aplikacja konsolowa

1. Program prosi o liczbę przedmiotów `n`.
2. Prosi o `seed` dla generatora pseudolosowego.
3. Tworzy instancję `Problem(n, seed)` i wypisuje listę wygenerowanych przedmiotów.
4. Prosi o pojemność plecaka `rozmiar`.
5. Zastosowuje algorytm zachłanny:
   - sortuje przedmioty malejąco według `Stosunek = Wartosc / Waga`
   - kolejno dodaje przedmiot do plecaka, jeśli mieści się w dopuszczalnym limicie wagi.
6. Wyświetla wynik (`Plecak`): wybrane ID przedmiotów, całkowitą wagę, całkowitą wartość.

## Przykładowe użycie

```bash
cd Lab2/ConsoleApp
dotnet run --project ConsoleApp.csproj
```

Wejście:
- `10` (liczba przedmiotów)
- `123` (seed)
- `20` (pojemność plecaka)

Wyjście: lista przedmiotów i rozwiązanie plecakowe.

## Jak uruchomić aplikację okienkową

```bash
cd Lab2/WindowApp/WindowApp
dotnet run --project WindowApp.csproj
```

W oknie wpisz:
- liczba przedmiotów (N)
- seed
- pojemność plecaka

Kliknij `Uruchom algorytm`.

## Jak uruchomić testy

```bash
cd Lab2/TestinngApp
dotnet test
```

## Uwagi

- Rozwiązanie jest przybliżone i typowe dla wariantu plecaka 0/1 z metodą zachłanną; nie zawsze daje optymalny wynik.
- Wagi i wartości są losowane z przedziału [1,9].
