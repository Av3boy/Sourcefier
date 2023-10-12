using System.ComponentModel.DataAnnotations;

namespace Sourcefier.ValidationAttributes;

public class ConditionalValidationAttribute<T> : ValidationAttribute
{
    public T ExpectedValue { get; set; }

    private bool AcceptAnythingElse { get; set; } = true;

    public ConditionalValidationAttribute(T expectedValue)
    {
        ExpectedValue = expectedValue;
    }

    public ConditionalValidationAttribute(T expectedValue, bool acceptAnythingElse)
    {
        ExpectedValue = expectedValue;
        AcceptAnythingElse = acceptAnythingElse;
    }

    public override bool IsValid(object? value)
    {
        if (value is not T currentValue)
            return false;

        return EqualityComparer<T>.Default.Equals(ExpectedValue, currentValue) && !AcceptAnythingElse;
    }
}
