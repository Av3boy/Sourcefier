using Microsoft.AspNetCore.Components;

namespace Sourcefier.Shared;

public class FormControl<T> : ComponentBase
{
    [Parameter]
    public T Property { get; set; }

    [Parameter]
    public EventCallback<T> PropertyChanged { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public string Placeholder { get; set; }

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public string LabelText { get; set; }

    [Parameter]
    public string Id { get; set; }
}
