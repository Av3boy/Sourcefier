using Sourcefier.DTO.Enums;

namespace Sourcefier.DTO.Models;

public class BookModel : SourceModel
{
    public int? PageStartNumber { get; set; }
    public int? PageEndNumber { get; set; }
    public PublishEditionType PublishEditionType { get; set; } = PublishEditionType.Basic;

    public bool IsEBook { get; set; } = false;
    public string? PublishEdition { get; set; }
    public string? Publisher { get; set; }
    public int? YearPublished { get; set; }
}
