using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class ProductsUi
{
    private readonly IProductBrowser _productBrowser;

    public ProductsUi(IProductBrowser productBrowser)
    {
        _productBrowser = productBrowser;
    }

    public void Run()
    {
        // PrintProducts("All products", _productBrowser.GetAll());
        // PrintProducts("Shirts", _productBrowser.GetByName("shirt"));
        // PrintProducts("Blue products", _productBrowser.GetByColor(Color.Blue));
        PrintProducts("Autumn products", _productBrowser.GetBySeason(Season.Autumn));
        
    }

    private static void PrintProducts(string text, IEnumerable<Product> products)
    {
        Console.WriteLine($"{text}: ");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}
