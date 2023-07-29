using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;

namespace CodeCool.SeasonalProductDiscounter.Service.Logger;

public class FileLogger: IFileLogger
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    private readonly IProductStatistics _productStatistics;

    public FileLogger(IProductStatistics productStatistics)
    {
        _productStatistics = productStatistics;
    }

    public void CreateFileLog()
    {
        var file = $"{WorkDir}/seasonalProductStatistics.txt";

        using var writer = new StreamWriter(file);
        foreach (var priceRangeToAvgPrice in _productStatistics.GetAveragePricesByPriceRange())
        {
            writer.WriteLine($"{priceRangeToAvgPrice.Key}: {priceRangeToAvgPrice.Value:N2}");
        }
        Console.WriteLine("Data has been written to the file.");
    }
}