using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Products.Browser;

public class ProductBrowser: IProductBrowser
{
    private readonly IEnumerable<Product> _products;

    public ProductBrowser(IEnumerable<Product> products)
    {
        _products = products;
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public IEnumerable<Product> GetByName(string name)
    {
        return _products.Where(p => p.Name.Contains(name));
    }

    public IEnumerable<Product> GetByColor(Color color)
    {
        return _products.Where(p => p.Color == color);
    }

    public IEnumerable<Product> GetBySeason(Season season)
    {
        return _products.Where(p => p.Season == season);
    }

    public IEnumerable<Product> GetByPriceSmallerThan(double price)
    {
        return _products.Where(p => p.Price < price);
    }

    public IEnumerable<Product> GetByPriceGreaterThan(double price)
    {
        return _products.Where(p => p.Price > price);
    }

    public IEnumerable<Product> GetByPriceRange(double minimumPrice, double maximumPrice)
    {
        return _products.Where(p => new PriceRange(minimumPrice, maximumPrice).Contains(p.Price));
    }

    public IEnumerable<IGrouping<string, Product>> GroupByName()
    {
        return _products.GroupBy(p => p.Name);
    }

    public IEnumerable<IGrouping<Color, Product>> GroupByColor()
    {
        return _products.GroupBy(p => p.Color);
    }

    public IEnumerable<IGrouping<Season, Product>> GroupBySeason()
    {
        return _products.GroupBy(p => p.Season);
    }

    public IEnumerable<IGrouping<PriceRange, Product>> GroupByPriceRange()
    {
        return _products.GroupBy(p =>
        {
            return p.Price switch
            {
                <= 20.00 => new PriceRange(0.00, 20.00),
                <= 30.00 => new PriceRange(11.00, 30.00),
                <= 40.00 => new PriceRange(31.00, 40.00),
                _ => new PriceRange(41.00, double.MaxValue)
            };
        });
    }

    public IEnumerable<Product> OrderByName()
    {
        return _products.OrderBy(p => p.Name);
    }

    public IEnumerable<Product> OrderByColor()
    {
        return _products.OrderBy(p => p.Color);
    }

    public IEnumerable<Product> OrderBySeason()
    {
        return _products.OrderBy(p => p.Season);
    }

    public IEnumerable<Product> OrderByPrice()
    {
        return _products.OrderBy(p => p.Price);
    }
}