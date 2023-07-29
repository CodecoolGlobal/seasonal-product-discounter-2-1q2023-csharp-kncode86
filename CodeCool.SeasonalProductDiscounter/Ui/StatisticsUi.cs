using CodeCool.SeasonalProductDiscounter.Service.Logger;
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
        ILogger logger = new ConsoleLogger();
        foreach (var priceRangeToAvgPrice in _productStatistics.GetAveragePricesByPriceRange())
        {
            logger.LogInfo($"{priceRangeToAvgPrice.Key}: {priceRangeToAvgPrice.Value:N2}");
        }
    }
}
