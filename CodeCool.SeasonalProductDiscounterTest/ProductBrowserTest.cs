﻿using System.Drawing;
using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
using Color = CodeCool.SeasonalProductDiscounter.Model.Enums.Color;

namespace CodeCool.SeasonalProductDiscounterTest;

public class ProductBrowserTest
{
    private readonly IProductBrowser _productBrowser;
    private readonly RandomProductGenerator _provider;

    private static readonly object[] Names =
    {
        "skirt",
        "T-shirt",
        "jacket",
        "shirt",
        "hat",
        "gloves"
    };

    private static readonly List<Color> Colors = Enum.GetValues<Color>().ToList();
    
    public ProductBrowserTest()
    {
        _provider = new RandomProductGenerator(50, 10, 70);
        _productBrowser = new ProductBrowser(_provider.Products);
    }
    
    [Test]
    public void GetAll()
    {
        var expected = _provider.Products;
        var actual = _productBrowser.GetAll();
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [TestCaseSource(nameof(Names))]
    public void GetByName(string name)
    {
        var expected = _provider.Products.Where(p => p.Name.Contains(name));
        var actual = _productBrowser.GetByName(name);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
    [TestCaseSource(nameof(Colors))]
    public void GetByColor(Color color)
    {
        var expected = _provider.Products.Where(p => p.Color == color);
        var actual = _productBrowser.GetByColor(color);

        Assert.That(actual, Is.EquivalentTo(expected));
    }
}
