using Sourcefier.DTO.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Sourcefier.DTO;

public class Model
{
    public ObservableRangeCollection<AuthorDto> Authors { get; set; } = new();

    [Required]
    public int? ReleaseYear { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public SourceType Type { get; set; } = SourceType.Unknown;
    public string OtherInfo { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Other { get; set; } = string.Empty;

    [Required]
    public DateOnly DateReferred { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required]
    public string Link { get; set; } = string.Empty;
    public string PublishEdition { get; set; } = string.Empty;

    public string School { get; set; } = string.Empty;

}