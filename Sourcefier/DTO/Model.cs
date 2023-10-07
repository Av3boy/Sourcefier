using Sourcefier.DTO.Enums;

namespace Sourcefier.DTO;

public class Model
{
    public IEnumerable<AuthorDto> Authors { get; set; } = Enumerable.Empty<AuthorDto>();

    public int? ReleaseYear { get; set; }
    public string Title { get; set; } = string.Empty;
    public SourceType Type { get; set; }
    public string OtherInfo { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Other { get; set; } = string.Empty;
    public DateOnly DateReferred { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public string Link { get; set; } = string.Empty;
    public string PublishEdition { get; set; } = string.Empty;

}