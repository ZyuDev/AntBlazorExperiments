using AntDesign;
using Company.WebApplication1.Models;
using Microsoft.AspNetCore.Components;

namespace AntExperiments.Pages;

public partial class RightsPage: ComponentBase
{
    private RightsPageViewModel _model = new RightsPageViewModel();
    private ITable _antTable;
    
    protected override void OnInitialized()
    {
        _model.Init(50);
    }

    private void OnAddClick()
    {
        var newName = $"Object {_model.Rights.Count + 1}";
        _model.AddRow(newName);

    }

    private void OnCheckReadClicked()
    {
        _model.ColumnCheck(1);
    }
    
    private void OnUnCheckReadClick()
    {
        _model.ColumnUnCheck(1);
    }
}