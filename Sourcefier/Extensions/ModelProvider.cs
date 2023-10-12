using Sourcefier.DTO.Enums;
using Sourcefier.DTO.Models;

namespace Sourcefier.Extensions;

public static class ModelProvider
{
    public static SourceModel GetModel(this SourceType type)
        => type switch
        {
            SourceType.Unknown => new UnknownModel(),
            SourceType.Thesis => new ThesisModel(),
            SourceType.Book => new BookModel(),
            SourceType.Record => new RecordModel(),
            SourceType.Email => new EmailModel(),
            SourceType.WebPublication => new WebPublicationModel(),
            SourceType.Legislation => new LegislationModel(),
            SourceType.Article => new ArticleModel(),
            SourceType.Publication => new PublicationModel(),
            SourceType.Movie => new MovieModel(),
            _ => throw new InvalidOperationException()
        };
}
