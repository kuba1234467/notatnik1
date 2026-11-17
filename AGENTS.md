# Katalog — zasady projektu

- Etykiety, przyciski i komunikaty są po polsku. Nazwy plików, klas i metod są po angielsku.
- Jeden ekran to para: jeden plik `.axaml` i jeden `.axaml.cs`. Dozwolony jest wspólny `CatalogItem.cs`. Nie dodawaj innych plików bez prośby.
- Nie dodawaj do `.csproj` żadnego `PackageReference`, którego nie było w szablonie.
- Nie używaj `{Binding}`, `DataContext` ani `x:DataType`. Kontrolki wypełniasz w C#: `Text`, `Items.Add`, `Click`.
- Dane czytaj i zapisuj wyłącznie w `dane/pozycje.txt`, linia `tytuł;rok;ocena`. Każdy ekran, który pokazuje pozycję, sam czyta ten plik — nie przekazuj gotowego obiektu zamiast odczytu.
- Kodowanie plików: UTF-8.
- Zmieniaj tylko pliki potrzebne do bieżącej prośby. `MainWindow` wolno ruszyć wyłącznie po to, by podstawić inny ekran pod `Content`.
- Metoda ma robić jedną rzecz i mieć co najwyżej 20 linii.
- Przełączanie ekranów: jedno okno, nowy `UserControl` w `Window.Content`.
