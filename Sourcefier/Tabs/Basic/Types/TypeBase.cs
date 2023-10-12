using Microsoft.AspNetCore.Components;
using Sourcefier.DTO.Models;

namespace Sourcefier.Tabs.Basic.Types;

public class TypeBase<T> : ComponentBase where T : SourceModel, new()
{
    [CascadingParameter]
    protected T Model { get; set; } = default!;
}
