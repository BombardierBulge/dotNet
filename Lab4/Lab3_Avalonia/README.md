# Lab3_Avalonia

## Opis projektu

Graficzna aplikacja napisana w Avalonia UI do przetwarzania obrazów z wykorzystaniem wielowątkowości. Program pozwala na:

- Ładowanie obrazów z dysku
- Stosowanie czterech różnych filtrów graficznych równolegle:
  - **Negatyw** (odwrócenie kolorów)
  - **Skala szarości** (konwersja do odcieni szarości)
  - **Próg** (binaryzacja na podstawie średniej jasności)
  - **Zielony odcień** (zwiększenie komponentu zielonego)

Filtry są przetwarzane równolegle przy użyciu `Parallel.Invoke` dla optymalizacji wydajności.

## Wymagania

- .NET 10.0 lub nowszy
- Avalonia UI
- SkiaSharp
- System operacyjny: Windows, Linux lub macOS

## Jak uruchomić

1. Przejdź do katalogu projektu:
   ```
   cd Lab4/Lab3_Avalonia
   ```

2. Przywróć zależności:
   ```
   dotnet restore
   ```

3. Uruchom aplikację:
   ```
   dotnet run
   ```

## Jak używać

1. **Ładowanie obrazu**: Kliknij przycisk "Wybierz obraz" i wybierz plik graficzny z dysku
2. **Przetwarzanie**: Kliknij przycisk "Przetwarzaj" - obraz zostanie przetworzony wszystkimi filtrami równolegle
3. **Wyniki**: Cztery przetworzone wersje obrazu pojawią się obok oryginału

## Funkcjonalności

- **Wielowątkowe przetwarzanie**: Wszystkie filtry są stosowane równolegle dla maksymalnej wydajności
- **Obsługa formatów**: Wspiera popularne formaty obrazów (JPEG, PNG, BMP, itp.)
- **Interfejs użytkownika**: Prosty i intuicyjny interfejs oparty na Avalonia UI
- **Status przetwarzania**: Wskaźnik postępu informuje o stanie operacji

## Uwagi techniczne

- Przetwarzanie jest wykonywane w tle, aby nie blokować interfejsu użytkownika
- Dla dużych obrazów czas przetwarzania może być dłuższy
- Aplikacja wykorzystuje SkiaSharp do manipulacji pikselami
- Filtry są stosowane niezależnie do kopii oryginalnego obrazu