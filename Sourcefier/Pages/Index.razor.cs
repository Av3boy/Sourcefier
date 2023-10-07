using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Sourcefier.DTO.Enums;

namespace Sourcefier.Pages;

public partial class Index
{

    #region Properties

    [Inject]
    private NavigationManager _navigationManager { get; init; } = default!;

    [Parameter]
    [SupplyParameterFromQuery]
    public string? Lang { get; set; }

    protected Mode Mode { get; set; } = Mode.Basic;

    protected Language Language { get; set; } = Language.Finnish;

    #endregion

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(Lang))
            return;

        if (Lang == "fi")
            Language = Language.Finnish;
        else if (Lang == "en")
            Language = Language.English;
    }

    protected void OnLangaugeChange(Language language)
    {
        Language = language;

        string lang = language == Language.Finnish ? "fi" : "en";
        _navigationManager.NavigateTo($"?lang={lang}", false);
    }
}
