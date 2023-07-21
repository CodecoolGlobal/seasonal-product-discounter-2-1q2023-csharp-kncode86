using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

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
        // return new ProductProvider().Products;
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
        return _products.Where(p => p.Price > minimumPrice && p.Price < maximumPrice);
    }

    public IEnumerable<IGrouping<string, Product>> GroupByName()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IGrouping<Color, Product>> GroupByColor()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IGrouping<Season, Product>> GroupBySeason()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IGrouping<PriceRange, Product>> GroupByPriceRange()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> OrderByName()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> OrderByColor()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> OrderBySeason()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> OrderByPrice()
    {
        throw new NotImplementedException();
    }
}