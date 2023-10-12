namespace Sourcefier.DTO.Models;

public class RecordModel : SourceModel
{
    public string? Format { get; set; }

    public string? Description { get; set; }

    public LocationType LocationType { get; set; }

    public DateOnly DateAccessed { get; set; }
}

public enum LocationType
{
    Digital,
    Physical
}
