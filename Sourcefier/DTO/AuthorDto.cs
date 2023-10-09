namespace Sourcefier.DTO;

public class AuthorDto
{
    public AuthorDto() 
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public char Initial { get; set; }
    public string? LastName { get; set; }
}
