namespace Sourcefier.DTO.Models;

public class LegislationModel : SourceModel
{
    public string? LawNumber { get; set; }
    public string? Name { get; set; }

    public DateOnly DateIssued { get; set; }

    public bool ChangedAfterIssue { get; set; }

    public DateOnly DateLastChanged { get; set; }
}
