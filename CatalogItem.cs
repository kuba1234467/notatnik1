namespace katalog;

public class CatalogItem
{
    public string Title { get; }
    public int Year { get; }
    public int Rating { get; }

    public CatalogItem(string title, int year, int rating)
    {
        Title = title;
        Year = year;
        Rating = rating;
    }

    public static bool TryParse(string line, out CatalogItem? item)
    {
        item = null;
        var parts = line.Split(';');
        if (parts.Length != 3)
            return false;
        if (!int.TryParse(parts[1].Trim(), out var year))
            return false;
        if (!int.TryParse(parts[2].Trim(), out var rating))
            return false;

        item = new CatalogItem(parts[0].Trim(), year, rating);
        return true;
    }
}
