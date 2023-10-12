namespace Sourcefier.DTO.Models;

public class ArticleModel : SourceModel
{
    public string? Paper { get; set; }
    public int VolumeNumber { get; set; }
    public string? PageNumber { get; set; }
}
