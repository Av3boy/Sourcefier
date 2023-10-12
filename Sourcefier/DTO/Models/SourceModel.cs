using Sourcefier.DTO.Enums;
using Sourcefier.ValidationAttributes;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Sourcefier.DTO.Models;

public class SourceModel : ISourceModel
{
    public ObservableRangeCollection<AuthorDto> Authors { get; set; } = new();
    public DateOnly DateReferred { get; set; }
    public string Link { get; set; } = string.Empty;
    public string OtherInfo { get ; set; } = string.Empty;
    public string Title { get; set ; } = string.Empty;
    public SourceType Type { get; set; } = SourceType.Unknown;
    public int? ReleaseYear { get; set; } = DateTime.Now.Year;
}