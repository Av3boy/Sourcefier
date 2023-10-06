using System.Text;
using static Sourcefier.Pages.Index;

namespace Sourcefier.Pages;

public partial class Index
{
    Model FormModel { get; set; } = new Model();

    public string Source { get; set; }

    private int numAuthors { get; set; }

    private void AddAuthor() => numAuthors += 1;
    private void RemoveAuthor() => numAuthors -= 1;

    private bool ReleaseKnown { get; set; } = false;
    private bool AuthorKnown { get; set; } = true;


    protected void CreateSource()
    {
        StringBuilder sourceBuilder = new StringBuilder();

        // Step 1: Who
        if (numAuthors > 0)
        {
            string authors = GetAuthorsString();
            sourceBuilder.Append(authors);

            // Step 2: When
            if (ReleaseKnown)
                sourceBuilder.Append($"{FormModel.ReleaseYear} ");
            else
                sourceBuilder.Append("N.d. ");
        }

        // Step 3: What
        sourceBuilder.Append($"{FormModel.Title}. ");

        // Step 4: Where
        string sourceType = GetSourceType();
        sourceBuilder.Append(sourceType);

        // TODO: Add other fields
        /*
            sourceBuilder.Append("painos");
            sourceBuilder.Append("kustantaja");
            sourceBuilder.Append("julkaisutyyppi");
            sourceBuilder.Append("muut tiedot");
            sourceBuilder.Append("julkaisija");
            sourceBuilder.Append("täsmentävät tiedot");
        */


        sourceBuilder.Append($"Viitattu: {FormModel.DateReferred}. ");
        sourceBuilder.AppendLine(LinkSourceText);

        Source = sourceBuilder.ToString();
    }

    private string LinkSourceText
        => $"{FormModel.Link}.";
        
    private string GetSourceType()
    {
        switch (FormModel.Type)
        {
            case SourceType.Thesis:
                break;

            case SourceType.Book:
                break;

            case SourceType.Record:
                break;

            case SourceType.Email:
                break;

            case SourceType.CDOrDvd:
                break;

            case SourceType.Unknown:
            default:
                break;
        }

        return string.Empty;
    }

    private string GetAuthorsString()
    {
        StringBuilder authorBuilder = new StringBuilder();

        using IEnumerator<AuthorDto> authors = FormModel.Authors.GetEnumerator();

        bool hasMoreItems = authors.MoveNext();
        while (hasMoreItems)
        {
            authorBuilder.Append($"{authors.Current.LastName}, {authors.Current.Initial}.");
            hasMoreItems = authors.MoveNext();

            // Has one more item
            if (hasMoreItems && !authors.MoveNext())
                authorBuilder.Append("& ");

            // Has more than one more item
            else if (hasMoreItems)
                authorBuilder.Append(", ");
        }

        return authorBuilder.ToString();
    }

    private async Task AuthorChanged(AuthorDto author, int index)
    {
        // TODO:
    }
}
