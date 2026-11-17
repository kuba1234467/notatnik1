using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class DetailsScreen : UserControl
{
    private readonly MainWindow? _window;

    public DetailsScreen()
    {
        InitializeComponent();
    }

    public DetailsScreen(MainWindow window, string title) : this()
    {
        _window = window;
        ShowItem(title);
    }

    private void ShowItem(string title)
    {
        var item = FindByTitle(title);
        if (item is null)
        {
            TitleText.Text = "Nie znaleziono pozycji w pliku.";
            return;
        }

        TitleText.Text = $"Tytuł: {item.Title}";
        YearText.Text = $"Rok: {item.Year}";
        RatingText.Text = $"Ocena: {item.Rating}";
    }

    private static CatalogItem? FindByTitle(string title)
    {
        if (!File.Exists("dane/pozycje.txt"))
            return null;

        foreach (var line in File.ReadAllLines("dane/pozycje.txt"))
        {
            if (!CatalogItem.TryParse(line, out var item) || item is null)
                continue;
            if (item.Title == title)
                return item;
        }

        return null;
    }

    private void OnBackClick(object? sender, RoutedEventArgs e)
    {
        _window?.ShowList();
    }
}
