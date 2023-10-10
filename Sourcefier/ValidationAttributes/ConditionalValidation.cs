using System.ComponentModel.DataAnnotations;

namespace Sourcefier.ValidationAttributes;

public class ConditionalValidation<T> : ValidationAttribute
{
    public T ExpectedValue { get; set; }

    public ConditionalValidation(T expectedValue)
    {
        ExpectedValue = expectedValue;
    }

    public override bool IsValid(object? value)
    {
        if (!(value is T currentValue))
            return false;

        return EqualityComparer<T>.Default.Equals(ExpectedValue, currentValue);
    }
}
