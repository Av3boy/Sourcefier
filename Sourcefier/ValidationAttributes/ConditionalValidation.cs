using System.ComponentModel.DataAnnotations;

namespace Sourcefier.ValidationAttributes;

public class ConditionalValidation<T> : ValidationAttribute
{
    public T ExpectedValue { get; set; }

    private bool _acceptAnythingElse { get; set; } = true;

    public ConditionalValidation(T expectedValue)
    {
        ExpectedValue = expectedValue;
    }

    public ConditionalValidation(T expectedValue, bool acceptAnythingElse)
    {
        ExpectedValue = expectedValue;
        _acceptAnythingElse = acceptAnythingElse;
    }

    public override bool IsValid(object? value)
    {
        if (!(value is T currentValue))
            return false;

        return EqualityComparer<T>.Default.Equals(ExpectedValue, currentValue) && !_acceptAnythingElse;
    }
}
