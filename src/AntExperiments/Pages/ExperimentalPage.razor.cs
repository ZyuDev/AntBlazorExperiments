using Microsoft.AspNetCore.Components;

namespace AntExperiments.Pages;

public partial class ExperimentalPage: ComponentBase
{
    private int _counter;
    private void OnButtonClicked()
    {
        _counter++;
    }
}