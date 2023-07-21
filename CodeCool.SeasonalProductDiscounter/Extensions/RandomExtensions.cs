namespace CodeCool.SeasonalProductDiscounter.Extensions;

public class RandomExtensions
{
    private static readonly Random Random = new();
    
    public static double GetRandomPrice(double minimumPrice, double maximumPrice)
    {
        return minimumPrice + Random.NextDouble() * (maximumPrice - minimumPrice);
    }
}