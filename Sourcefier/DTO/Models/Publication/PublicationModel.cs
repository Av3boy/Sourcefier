using System.ComponentModel.DataAnnotations;

namespace Sourcefier.DTO.Models;

public class PublicationModel : SourceModel
{
    public string? Reporter { get; set; }

    [Required]
    public int? YearPublished { get; set; }

    public int ReleaseNumber { get; set; }
}
