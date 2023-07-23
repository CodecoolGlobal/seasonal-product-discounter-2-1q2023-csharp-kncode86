using CodeCool.SeasonalProductDiscounter.Service.Products.Browser;
using CodeCool.SeasonalProductDiscounter.Service.Products.Provider;
using CodeCool.SeasonalProductDiscounter.Service.Products.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui;

var productProvider = new RandomProductGenerator(100, 10, 50);
IProductBrowser productBrowser = new ProductBrowser(productProvider.Products);
IProductStatistics productStatistics = new ProductStatistics(productProvider.Products);

var productsUi = new ProductsUi(productBrowser);
var statisticsUi = new StatisticsUi(productStatistics);

//productsUi.Run();
statisticsUi.Run();
