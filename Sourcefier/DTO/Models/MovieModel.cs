namespace Sourcefier.DTO.Models;

public class MovieModel : SourceModel
{
    public bool MovieBroadcasted { get; set; }

    public string? BroadcastPlatform { get; set; }

    public DateOnly BroadcastDate { get; set; }
}
