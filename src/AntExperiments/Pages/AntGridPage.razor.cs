using AntDesign;
using Bogus;

namespace AntExperiments.Pages;

public partial class AntGridPage
{
    public bool IsLoading { get; set; }
    public int Total { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public List<Model>? Items { get; set; }

    private List<Model>? _testData;

    protected override void OnInitialized()
    {
        _testData = GenerateTestData(15);

        Total = _testData.Count;
        PageSize = 5;

        LoadPagedData(1, PageSize);
    }

    private void LoadPagedData(int page, int pageSize)
    {
        Items = _testData?.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        PageIndex = page;
    }

    private void OnPageChanged(PaginationEventArgs p)
        => LoadPagedData(p.Page, p.PageSize);

    private List<Model> GenerateTestData(int size)
    {
        var testData = new List<Model>();
        var model = new Faker<Model>()
            .RuleFor(m => m.Id, f => f.IndexFaker)
            .RuleFor(m => m.FirstName, (f, _) => f.Name.FirstName())
            .RuleFor(m => m.LastName, (f, _) => f.Name.LastName())
            .RuleFor(m => m.Email, (f, m) => f.Internet.Email(m.FirstName, m.LastName))
            .RuleFor(m => m.Value, f => $"Value {f.UniqueIndex}");

        for (var i = 0; i < size; i++)
        {
            testData.Add(model.Generate());
        }

        return testData.OrderBy(x => x.Id).ToList();
    }
}

public class Model
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Value { get; set; }
}