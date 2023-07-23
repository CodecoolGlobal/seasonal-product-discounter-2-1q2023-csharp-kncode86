using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

namespace CodeCool.SeasonalProductDiscounterTest;

public class ProductStatisticsTest
{
    private readonly RandomProductGenerator _provider;
    private readonly IProductStatistics _statistics;

    public ProductStatisticsTest()
    {
        _provider = new RandomProductGenerator(50, 10, 70);
        _statistics = new ProductStatistics(_provider.Products);
    }

    [Test]
    public void MostExpensive()
    {
        var expected = _provider.Products.MaxBy(p => p.Price);
        var actual = _statistics.GetMostExpensive();

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void MostCheapest()
    {
        var expected = _provider.Products.MinBy(p => p.Price);
        var actual = _statistics.GetCheapest();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AveragePrice()
    {
        var expected = _provider.Products.Average(p => p.Price);
        var actual = _statistics.GetAveragePrice();
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AveragePricesByName()
    {
        var expected = _provider.Products.GroupBy(p => p.Name).ToDictionary(g => g.Key, g => g.Average(p => p.Price));
        var actual = _statistics.GetAveragePricesByName();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
    [Test]
    public void AveragePricesByColor()
    {
        var expected = _provider.Products.GroupBy(p => p.Color).ToDictionary(g => g.Key, g => g.Average(p => p.Price));
        var actual = _statistics.GetAveragePricesByColor();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
    [Test]
    public void AveragePricesBySeason()
    {
        var expected = _provider.Products.GroupBy(p => p.Season).ToDictionary(g => g.Key, g => g.Average(p => p.Price));
        var actual = _statistics.GetAveragePricesBySeason();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
    [Test]
    public void AveragePricesByPriceRange()
    {
        var expected = _provider.Products.GroupBy(p => {
            return p.Price switch
            {
                <= 20.00 => new PriceRange(0.00, 20.00),
                <= 30.00 => new PriceRange(21.00, 30.00),
                <= 40.00 => new PriceRange(31.00, 40.00),
                _ => new PriceRange(41.00, 100.00)
            };
        }).ToDictionary(g => g.Key, g => g.Average(p => p.Price));
        var actual = _statistics.GetAveragePricesByPriceRange();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void CountByName()
    {
        var expected = _provider.Products.GroupBy(p => p.Name).ToDictionary(g => g.Key, g => g.Count());
        var actual = _statistics.GetCountByName();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
    [Test]
    public void CountByColor()
    {
        var expected = _provider.Products.GroupBy(p => p.Color).ToDictionary(g => g.Key, g => g.Count());
        var actual = _statistics.GetCountByColor();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
    [Test]
    public void CountBySeason()
    {
        var expected = _provider.Products.GroupBy(p => p.Season).ToDictionary(g => g.Key, g => g.Count());
        var actual = _statistics.GetCountBySeason();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
    [Test]
    public void CountByPriceRange()
    {
        var expected = _provider.Products.GroupBy(p =>  {
            return p.Price switch
            {
                <= 20.00 => new PriceRange(0.00, 20.00),
                <= 30.00 => new PriceRange(21.00, 30.00),
                <= 40.00 => new PriceRange(31.00, 40.00),
                _ => new PriceRange(41.00, 100.00)
            };
        }).ToDictionary(g => g.Key, g => g.Count());
        var actual = _statistics.GetCountByPriceRange();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
