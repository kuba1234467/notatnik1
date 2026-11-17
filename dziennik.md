# Dziennik weryfikacji

## 2026-11-17 — przegląd budowy 2 przyjęty bez sprawdzenia

- Sprawdzone: nic, bo przyjęcie było oparte na tym, że kod wygląda sensownie i wywołuje pożądane metody.
- Wynik: przyjęto projekt bez odpytania o wynik, bez zbudowania i bez sprawdzenia, czy dane zapisują się zgodnie z opisem.
- Nie wiadomo: czy data i nazwy ekranów są rzeczywiście odczytywane poprawnie z katalogu `dane/pozycje.txt` po uruchomieniu z innego katalogu roboczego.

## 2026-11-17 — sprawdzenie dzisiejsze

- Sprawdzone: `dotnet build --nologo` → kompilacja powiodła się, 0 błędów, 0 ostrzeżeń.
- Sprawdzone: `dotnet run --project katalog.csproj --no-build` → aplikacja uruchamia się bez błędu startu i ładuje ekran listy.
- Sprawdzone: zapis nowej pozycji do `dane/pozycje.txt` i odczyt z powrotem po przejściu do szczegółów → pozycja pojawia się zgodnie z opisem i nie znika po przełączeniu ekranów.
- Nie wiadomo: co stanie się, gdy aplikacja uruchomi się poza katalogiem projektu i ścieżka względna `dane/pozycje.txt` nie będzie poprawna.

## Nazwa do sprawdzenia w dokumentacji

- Nazwa: `Window.Content`
- Data odczytania: 2026-11-17
- Dokumentacja: https://docs.avaloniaui.net/docs/controls/window
- Co robi: `Window.Content` to właściwość ustawiająca główną zawartość okna — w projekcie służy do podmieniania ekranu listy, szczegółów i dodawania bez tworzenia osobnego okna.
