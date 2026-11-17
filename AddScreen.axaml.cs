using System.IO;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class AddScreen : UserControl
{
    private readonly MainWindow? _window;

    public AddScreen()
    {
        InitializeComponent();
    }

    public AddScreen(MainWindow window) : this()
    {
        _window = window;
    }

    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        if (!TryReadForm(out var item) || item is null)
            return;

        AppendItem(item);
        _window?.ShowList();
    }

    private bool TryReadForm(out CatalogItem? item)
    {
        item = null;
        var title = TitleBox.Text?.Trim() ?? "";
        if (title.Length == 0)
            return ShowError("Podaj tytuł.");
        if (title.Contains(';'))
            return ShowError("Tytuł nie może zawierać średnika.");
        if (!int.TryParse(YearBox.Text, out var year))
            return ShowError("Rok musi być liczbą całkowitą.");
        if (!int.TryParse(RatingBox.Text, out var rating))
            return ShowError("Ocena musi być liczbą całkowitą.");

        item = new CatalogItem(title, year, rating);
        return true;
    }

    private bool ShowError(string message)
    {
        ErrorText.Text = message;
        return false;
    }

    private static void AppendItem(CatalogItem item)
    {
        var line = $"{item.Title};{item.Year};{item.Rating}";
        File.AppendAllText("dane/pozycje.txt", line + "\n", Encoding.UTF8);
    }

    private void OnCancelClick(object? sender, RoutedEventArgs e)
    {
        _window?.ShowList();
    }
}
