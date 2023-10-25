using System.ComponentModel.DataAnnotations;

namespace UserNotebook.Annotations;

public class BirthdayValidator : ValidationAttribute
{
    private readonly DateOnly _today = DateOnly.FromDateTime(DateTime.Today);

    public override bool IsValid(object? value)
    {
        var incoming = value as DateOnly?;
        
        return _today.CompareTo(incoming) >= 0;
    }
}