namespace AntExperiments.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string VendorCode { get; set; } = string.Empty;
    public int ProductGroupId { get; set; }
    public string ProductGroupTitle { get; set; } = string.Empty;
    public decimal Price { get; set; }

}