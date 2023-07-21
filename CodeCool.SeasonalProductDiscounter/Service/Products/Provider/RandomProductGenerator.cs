using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

public class RandomProductGenerator : IProductProvider
{
    private static readonly Random Random = new();
    private static readonly Color[] Colors = Enum.GetValues<Color>();
    private static readonly Season[] Seasons = Enum.GetValues<Season>();

    private static readonly string[] Names =
    {
        "skirt",
        "T-shirt",
        "jacket",
        "shirt",
        "hat",
        "gloves"
    };

    public IEnumerable<Product> Products { get; }

    public RandomProductGenerator(uint count, double minimumPrice, double maximumPrice)
    {
        Products = GenerateRandomProducts(count, minimumPrice, maximumPrice).ToList();
    }

    private static IEnumerable<Product> GenerateRandomProducts(uint count, double minimumPrice, double maximumPrice)
    {
        var products = new List<Product>();
        
        for (uint i = 0; i < count; i++)
        {
            var color = GetRandomColor();
            products.Add(new Product(i, GetRandomName(color), color, GetRandomSeason(), RandomExtensions.GetRandomPrice(minimumPrice, maximumPrice)));
        }
        
        return products;
    }

    private static Color GetRandomColor()
    {
        return Colors[Random.Next(Colors.Length)];
    }

    private static string GetRandomName(Color color)
    {
        return $"{color} {Names[Random.Next(Names.Length)]}";
    }

    private static Season GetRandomSeason()
    {
        return Seasons[Random.Next(Seasons.Length)];
    }

    /*
    private static double GetRandomPrice(double minimumPrice, double maximumPrice)
    {
        return minimumPrice + Random.NextDouble() * (maximumPrice - minimumPrice);
    }
    */
}
