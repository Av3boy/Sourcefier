using Microsoft.AspNetCore.Components;
using Sourcefier.Components;
using Sourcefier.DTO;
using Sourcefier.DTO.Enums;
using Sourcefier.DTO.Models;
using Sourcefier.Extensions;
using System.Reflection;
using System.Text;
using Microsoft.OpenApi.Extensions;

namespace Sourcefier.Tabs.Basic;

public partial class Basic : ComponentBase
{
    [Parameter]
    public bool ShowHelpText { get; set; }

    SourceModel FormModel { get; set; } = new SourceModel();

    public string Source { get; set; } = string.Empty;

    private int NumAuthors { get; set; }

    private bool ReleaseKnown { get; set; } = true;

    private bool NoAuthors { get; set; } = false;

    protected void TypeChanged(SourceType type)
    {
        FormModel = ModelProvider.GetModel(type);
        FormModel.Type = type;
        NoAuthors = FormModel.Type.HasFlag(SourceType.Legislation);
    }

    private void AddAuthor()
    {
        NumAuthors += 1;
    }

    private void RemoveAuthor(int index)
    {
        NumAuthors -= 1;
        FormModel.Authors.RemoveAt(index);
    }

    protected void OnReleaseKnownChanged(ChangeEventArgs e)
    {
        bool releaseKnown = (bool)e.Value!;
        ReleaseKnown = releaseKnown;

        // Release not kwown, use N.d. ("No date")
        if (!releaseKnown)
            FormModel.ReleaseYear = null;
    }

    protected void CreateSource()
    {
        StringBuilder sourceBuilder = new StringBuilder();

        // Step 1: Who
        if (NumAuthors > 0)
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
        // Add other fields based on the type of the model
        string typeInfo = HandleTypeInfo();
        sourceBuilder.Append(typeInfo);

        // Add the referral date. This is required for all types.
        sourceBuilder.Append($"Viitattu: {FormModel.DateReferred}. ");

        // Lastly, if the type requires a link, add it.
        sourceBuilder.AppendLine(LinkSourceText);

        Source = sourceBuilder.ToString();
    }

    private string HandleTypeInfo() => FormModel.Type switch
    {
        SourceType.Unknown => HandleUnknownType((FormModel as UnknownModel)!),
        SourceType.Book => HandleBookType((FormModel as BookModel)!),
        SourceType.Movie => HandleMovieType((FormModel as MovieModel)!),
        SourceType.Publication => HandlePublicationType((FormModel as PublicationModel)!),
        SourceType.Thesis => HandleThesisType((FormModel as ThesisModel)!),
        SourceType.Legislation => HandleLegislationType((FormModel as LegislationModel)!),
        SourceType.Article => HandleArticleType((FormModel as ArticleModel)!),
        SourceType.Record => HandleRecordType((FormModel as RecordModel)!),
        SourceType.WebPublication => HandleWebPublicationType((FormModel as WebPublicationModel)!),
        _ => throw new InvalidOperationException("Invalid type."),
    };

    private string HandleUnknownType(UnknownModel model)
        => throw new NotImplementedException();

    private string HandleBookType(BookModel model)
        => throw new NotImplementedException();

    private string HandleMovieType(MovieModel model)
        => throw new NotImplementedException();

    private string HandlePublicationType(PublicationModel model)
        => throw new NotImplementedException();

    private static string HandleThesisType(ThesisModel model)
        => $"{model.School}, {model.Level.GetDisplayName()}. ";

    private string HandleLegislationType(LegislationModel model)
        => throw new NotImplementedException();

    private string HandleArticleType(ArticleModel model)
        => throw new NotImplementedException();
    private string HandleRecordType(RecordModel model)
        => throw new NotImplementedException();

    private string HandleWebPublicationType(WebPublicationModel model)
        => throw new NotImplementedException();

    private string LinkSourceText
        => $"{FormModel.Link}.";

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
