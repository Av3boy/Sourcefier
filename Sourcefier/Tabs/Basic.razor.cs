using Microsoft.AspNetCore.Components;

using Sourcefier.Components;
using Sourcefier.DTO;
using Sourcefier.DTO.Enums;
using Sourcefier.Extensions;

using System.Text;

namespace Sourcefier.Tabs;

public partial class Basic
{
    [Parameter]
    public bool ShowHelpText { get; set; }

    Model FormModel { get; set; } = new Model();

    public string Source { get; set; } = string.Empty;

    private int numAuthors { get; set; }

    private bool ReleaseKnown { get; set; } = true;


    private async Task AddAuthor()
    {
        numAuthors += 1;
    }

    private void RemoveAuthor(int index)
    {
        numAuthors -= 1;
        FormModel.Authors.RemoveAt(index);
    }

    protected void OnReleaseKnownChanged(ChangeEventArgs e)
    {
        bool releaseKnown = (bool)e.Value!;
        ReleaseKnown = releaseKnown;

        if (releaseKnown)
            FormModel.ReleaseYear = null;
    }

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
                sourceBuilder.Append($"{FormModel.ReleaseYear}. ");
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
            authorBuilder.Append($"{authors.Current.LastName}, {char.ToUpper(authors.Current.Initial)}. ");
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

    private void AuthorChanged(AuthorDto author)
    {
        var authorElem = FormModel.Authors.FirstOrDefault(item => item.Id.Equals(author.Id));

        if (authorElem is null)
            throw new InvalidOperationException("Author not found.");

        authorElem!.LastName = author.LastName;
        authorElem!.Initial = author.Initial;
    }
}
