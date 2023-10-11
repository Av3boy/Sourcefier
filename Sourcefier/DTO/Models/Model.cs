using Sourcefier.DTO.Enums;
using Sourcefier.ValidationAttributes;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Sourcefier.DTO.Models;

public class Model : ISourceModel
{
    public ObservableRangeCollection<AuthorDto> Authors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateOnly DateReferred { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Link { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string OtherInfo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public SourceType? Type { get; set; } = SourceType.Unknown;
    public int? ReleaseYear { get; set; } = DateTime.Now.Year;
}