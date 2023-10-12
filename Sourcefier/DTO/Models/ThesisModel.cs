using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sourcefier.DTO.Models;

public class ThesisModel : SourceModel
{
    public string? School { get; set; }
    public ThesisType Level { get; set; }
    public bool IsFaculty { get; set; }
    public string? Faculty { get; set; }
}

public enum ThesisType
{
    [Display(Name = "AMK")]
    Bachelor,

    [Display(Name = "YAMK")]
    Master,

    [Display(Name = "Pro Gradu")]
    Doctorate,

    [Display(Name = "Diplomityö")]
    Diploma
}