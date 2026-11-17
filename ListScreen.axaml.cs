using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class ListScreen : UserControl
{
    private readonly MainWindow? _window;

    public ListScreen()
    {
        InitializeComponent();
    }

    public ListScreen(MainWindow window) : this()
    {
        _window = window;
        LoadItems();
    }

    private void LoadItems()
    {
        ItemsList.Items.Clear();
        foreach (var item in ReadItems())
        {
            ItemsList.Items.Add(new ListBoxItem
            {
                Content = $"{item.Title} ({item.Year})",
                Tag = item
            });
        }
    }

    private static List<CatalogItem> ReadItems()
    {
        var items = new List<CatalogItem>();
        if (!File.Exists("dane/pozycje.txt"))
            return items;

        foreach (var line in File.ReadAllLines("dane/pozycje.txt"))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;
            if (CatalogItem.TryParse(line, out var item) && item is not null)
                items.Add(item);
        }

        return items;
    }

    private void OnDetailsClick(object? sender, RoutedEventArgs e)
    {
        if (ItemsList.SelectedItem is not ListBoxItem row || row.Tag is not CatalogItem item)
        {
            StatusText.Text = "Wybierz pozycję z listy.";
            return;
        }

        _window?.ShowDetails(item.Title);
    }

    private void OnAddClick(object? sender, RoutedEventArgs e)
    {
        StatusText.Text = "Formularz dodawania pojawi się w następnym kroku.";
    }
}
