namespace Sourcefier.Pages;

public partial class Index
{
    public class Model
    {
        public IEnumerable<AuthorDto> Authors { get; set; }

        public int? ReleaseYear { get; set; }
        public string Title { get; set; }
        public SourceType Type { get; set; }
        public string OtherInfo { get; set; }
        public string Publisher { get; set; }
        public string Other { get; set; }
        public DateOnly DateReferred { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Link { get; set; }
        public string PublishEdition { get; set; }

    }
}
