using Sourcefier.DTO.Enums;
using System.Collections.ObjectModel;

namespace Sourcefier.DTO.Models;

public interface ISourceModel
{
    public ObservableRangeCollection<AuthorDto> Authors { get; set; }
    public DateOnly DateReferred { get; set; }
    public string Link { get; set; }
    public string OtherInfo { get; set; }
    public string Title { get; set; }
    public SourceType Type { get; set; }

    public int? ReleaseYear { get; set; }
}