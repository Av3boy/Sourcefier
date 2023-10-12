namespace Sourcefier.DTO.Models;

public class EmailModel : SourceModel
{
    public string? Receiver { get; set; }

    public DateOnly DateSent { get; set; }

    public string? Subject { get; set; }

    public string? Contents { get; set; }

    public string? MoreInfo { get; set; }
}
