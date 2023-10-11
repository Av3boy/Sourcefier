using Sourcefier.DTO.Enums;

namespace Sourcefier.DTO.Models;

public class BookModel : Model
{
    public int? PageStartNumber { get; set; }
    public int? PageEndNumber { get; set; }
    public PublishEditionType PublishEditionType { get; set; } = PublishEditionType.Basic;

    public bool IsEBook { get; set; } = false;
    string PublishEdition { get; set; }

    string Publisher { get; set; }
    int? ReleaseYear { get; set; }

}
