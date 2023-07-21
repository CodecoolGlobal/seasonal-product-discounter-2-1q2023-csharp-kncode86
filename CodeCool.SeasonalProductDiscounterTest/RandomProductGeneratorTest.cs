using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

namespace CodeCool.SeasonalProductDiscounterTest;

public class RandomProductGeneratorTest
{
    private static readonly List<RandomProductGenerator> RandomProducts = new()
    {
        new RandomProductGenerator(10, 5, 50),
        new RandomProductGenerator(20, 10, 60),
        new RandomProductGenerator(30, 15, 70),
        new RandomProductGenerator(40, 20, 80),
    };

    [TestCaseSource(nameof(RandomProducts))]

    public void GetRandomProduct(RandomProductGenerator randomProduct)
    {
        Assert.That(randomProduct.Products, Is.TypeOf(typeof(List<Product>)));
    }
}