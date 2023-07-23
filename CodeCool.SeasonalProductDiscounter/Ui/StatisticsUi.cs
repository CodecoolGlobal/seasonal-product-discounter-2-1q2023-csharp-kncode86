using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class StatisticsUi
{
    private readonly IProductStatistics _productStatistics;

    public StatisticsUi(IProductStatistics productStatistics)
    {
        _productStatistics = productStatistics;
    }

    public void Run()
    {
        Console.WriteLine($"Most expensive product: {_productStatistics.GetMostExpensive()}");
        
        // foreach (var colorToAvgPrice in _productStatistics.GetAveragePricesByColor())
        // {
        //     Console.WriteLine($"{colorToAvgPrice.Key}: {colorToAvgPrice.Value:N2}");
        // }
    }
}
