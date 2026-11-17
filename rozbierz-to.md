# Rozbierz to — fragment z lekcji

Poniżej są trzy pozostałe błędy z fragmentu z początku lekcji. Każdy opisuje inną klasę halucynacji i ma własny test weryfikacyjny.

## 1) `SaveFileDialog` nie istnieje w tej wersji biblioteki

- Co jest nie tak: w kodzie użyto `SaveFileDialog`, a w Avalonia 12 ta klasa została usunięta. Zamiast niej używa się `IStorageProvider` i `SaveFilePickerAsync`.
- Kształt halucynacji: "Coś, czego nie ma." To nie błąd składni, tylko API, które przestało istnieć w najnowszej bibliotece.
- Kiedy się ujawnia: przy budowaniu projektu, bo kompilator od razu nie zna typu.
- Czym to sprawdzam: przez `dotnet build` oraz krótkie sprawdzenie dokumentacji Avalonia 12 / aktualnych przykładów. Jeśli odnajdę `SaveFileDialog` w kodzie albo w dokumentacji, to jest sygnał, że materiał jest przestarzały.
- O moim notatniku: w tym repozytorium nie ma tego błędu. Sprawdziłem to po repozytorium i przez `dotnet build --nologo` — kompilacja przechodzi bez błędów i nie ma żadnego użycia `SaveFileDialog`.

## 2) Timer aktualizuje widok z innego wątku

- Co jest nie tak: `autosaveTimer.Elapsed += (s, e) => StatusText.Text = "Zapisano";` uruchamia kod z timera z wątku z puli wątków. `StatusText.Text` jest elementem interfejsu, więc aktualizacja z innego wątku może wywołać wyjątek lub przynajmniej zachowanie niezgodne z frameworkiem.
- Kształt halucynacji: "Coś, co istnieje, użyte źle." To poprawny typ timera, tylko użyty w niewłaściwym miejscu i w niewłaściwym kontekście.
- Kiedy się ujawnia: przy uruchomieniu aplikacji, gdy timer wywoła `Elapsed` po upływie czasu; usterka pojawia się w czasie działania, nie na etapie kompilacji.
- Czym to sprawdzam: uruchamiam aplikację i obserwuję, czy po odliczeniu timera pojawia się wyjątek w konsoli/oknie diagnostycznym. Dodatkowo sprawdzam, czy kod modyfikuje kontrolkę z wątku nie-UI.
- O moim notatniku: w tym repozytorium nie ma tego błędu. Nie ma żadnego `System.Timers.Timer`, a ekran `ListScreen` i `AddScreen` aktualizują tekst wyłącznie w handlerach `Click` lub bezpośrednio po odczycie danych. Sprawdziłem to przez przegląd plików i uruchomienie `dotnet run --project katalog.csproj --no-build` bez błędu startu.

## 3) Komentarz o obsłudze błędów jest nieprawdziwy

- Co jest nie tak: komentarz mówi: "Obsługa błędów zapisu jest w środku.", ale w kodzie nie ma żadnej obsługi błędu. Brak `try/catch`, brak sprawdzenia `path`, brak sprawdzenia, czy użytkownik anulował wybór pliku. Kod po prostu wywołuje `File.WriteAllText(path, NoteBox.Text);` i zakłada, że wszystko się uda.
- Kształt halucynacji: "Zdanie o kodzie, które nie jest prawdą." To nie jest błąd kompilacji ani błąd wykonania od razu; to fałszywe twierdzenie, którego żadne narzędzie nie wykryje, dopóki ktoś nie przeczyta kodu.
- Kiedy się ujawnia: zwykle dopiero w momencie rzeczywistego działania, na przykład przy anulowaniu okna zapisu, pustej ścieżce albo błędzie zapisu do katalogu.
- Czym to sprawdzam: czytam dokładnie metodę `SaveButton_Click` i patrzę, czy istnieje obserwacja błędów: `try`, `catch`, walidacja `path`, wynik `ShowAsync`, czy logowanie. Jeśli nie ma niczego z tego, to stwierdzenie jest nieprawdziwe.
- O moim notatniku: w tym repozytorium nie ma takiego komentarza ani takiej konstrukcji. Sprawdziłem to przeglądem plików i wyszukiwaniem po `try`, `catch`, `File.WriteAllText` oraz `Obsługa błędów`.

## Krótka odpowiedź na pytanie z lekcji

Najpierw nie patrzymy na to, czy kod „ładnie wygląda”, tylko na to, czy buduje się, czy uruchamia się i czy robi dokładnie to, co ma robić. Za każdym razem sprawdzam trzy rzeczy: kompilację, uruchomienie i operację biznesową; dopiero potem przyjmuję wynik.
