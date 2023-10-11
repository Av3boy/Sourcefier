using Sourcefier.DTO.Enums;
using System.Collections.ObjectModel;

namespace Sourcefier.DTO.Models;

public interface ISourceModel
{
    ObservableRangeCollection<AuthorDto> Authors { get; set; }
    DateOnly DateReferred { get; set; }
    string Link { get; set; }
    string OtherInfo { get; set; }
    string Title { get; set; }
    SourceType? Type { get; set; }

    public int? ReleaseYear { get; set; }
}