using Sourcefier.DTO.Enums;

namespace Sourcefier.DTO;

public class BookModel
{
    public int? PageStartNumber { get; set; }
    public int? PageEndNumber { get; set; }
    public PublishEditionType PublishEditionType { get; set; } = PublishEditionType.Basic;
}
