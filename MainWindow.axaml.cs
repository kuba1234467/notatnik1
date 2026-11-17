using Avalonia.Controls;

namespace katalog;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ShowList();
    }

    public void ShowList()
    {
        Content = new ListScreen(this);
    }

    public void ShowDetails(CatalogItem item)
    {
        Content = new DetailsScreen(this, item);
    }
}
