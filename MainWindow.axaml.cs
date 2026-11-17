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

    public void ShowDetails(string title)
    {
        Content = new DetailsScreen(this, title);
    }

    public void ShowAdd()
    {
        Content = new AddScreen(this);
    }
}
