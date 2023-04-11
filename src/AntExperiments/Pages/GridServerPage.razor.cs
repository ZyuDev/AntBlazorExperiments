using AntDesign.TableModels;
using AntExperiments.Models;
using Microsoft.AspNetCore.Components;

namespace AntExperiments.Pages;

public partial class GridServerPage: ComponentBase
{
    private List<Product> _products;
    private List<Product> _remouteProducts;
    private int _pageIndex = 1;
    private  int _pageSize = 20;
    private int _total = 1000;
    private bool _isWaiting;

    protected override void OnInitialized()
    {
        _remouteProducts = GenerateRandomProducts(_total);
        _products = GetPageData(_pageIndex, _pageSize);
    }


    public List<Product> GenerateRandomProducts(int numberOfItems)
    {
        List<Product> products = new List<Product>();
        Random random = new Random();

        for (int i = 0; i < numberOfItems; i++)
        {
            Product product = new Product()
            {
                Id = random.Next(),
                Title = $"Product {i}",
                VendorCode = $"VC{i}",
                ProductGroupId = random.Next(),
                ProductGroupTitle = $"Product Group {random.Next(1, 10)}",
                Price = (decimal)(random.NextDouble() * 100)
            };

            products.Add(product);
        }

        return products;
    }
    
    public List<Product> GetPageData(int pageNumber, int pageSize)
    {
        var startIndex = (pageNumber - 1) * pageSize;
        var endIndex = Math.Min(startIndex + pageSize, _remouteProducts.Count);
        return _remouteProducts.GetRange(startIndex, endIndex - startIndex);
    }

    private void HandleTableChange(QueryModel<Product> queryModel)
    {
        _isWaiting = true;

        _products = GetPageData(_pageIndex, _pageSize);
        
        _isWaiting = false;
    }


}