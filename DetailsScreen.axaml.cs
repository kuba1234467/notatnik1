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

    public DetailsScreen(MainWindow window, CatalogItem item) : this()
    {
        _window = window;
        ShowItem(item);
    }

    private void ShowItem(CatalogItem item)
    {
        TitleText.Text = $"Tytuł: {item.Title}";
        YearText.Text = $"Rok: {item.Year}";
        RatingText.Text = $"Ocena: {item.Rating}";
    }

    private void OnBackClick(object? sender, RoutedEventArgs e)
    {
        _window?.ShowList();
    }
}
