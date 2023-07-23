using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

public class ProductStatistics: IProductStatistics
{
    private readonly IEnumerable<Product> _products;

    public ProductStatistics(IEnumerable<Product> products)
    {
        _products = products;
    }

    public Product? GetMostExpensive()
    {
        return _products.MaxBy(p => p.Price);
    }

    public Product? GetCheapest()
    {
        return _products.MinBy(p => p.Price);
    }

    public double GetAveragePrice()
    {
        return _products.Average(p => p.Price);
    }

    public Dictionary<string, double> GetAveragePricesByName()
    {
        return _products.GroupBy(p => p.Name).ToDictionary(g => g.Key, g => g.Average(p => p.Price));
    }

    public Dictionary<Color, double> GetAveragePricesByColor()
    {
        return _products.GroupBy(p => p.Color).ToDictionary(g => g.Key, g => g.Average(p => p.Price));
    }

    public Dictionary<Season, double> GetAveragePricesBySeason()
    {
        return _products.GroupBy(p => p.Season).ToDictionary(g => g.Key, g => g.Average(p => p.Price));
    }

    public Dictionary<PriceRange, double> GetAveragePricesByPriceRange()
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, int> GetCountByName()
    {
        return _products.GroupBy(p => p.Name).ToDictionary(g => g.Key, g => g.Count());
    }

    public Dictionary<Color, int> GetCountByColor()
    {
        return _products.GroupBy(p => p.Color).ToDictionary(g => g.Key, g => g.Count());
    }

    public Dictionary<Season, int> GetCountBySeason()
    {
        return _products.GroupBy(p => p.Season).ToDictionary(g => g.Key, g => g.Count());
    }

    public Dictionary<PriceRange, int> GetCountByPriceRange()
    {
        throw new NotImplementedException();
    }
}