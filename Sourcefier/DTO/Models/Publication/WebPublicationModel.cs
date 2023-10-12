namespace Sourcefier.DTO.Models;

public class WebPublicationModel : SourceModel
{
    public string? WebsiteName { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
