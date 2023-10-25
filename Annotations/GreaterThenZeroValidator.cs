using System.ComponentModel.DataAnnotations;

namespace UserNotebook.Annotations;

public class GreaterThenZeroValidator : ValidationAttribute
{
    private const double Minimum = 0;
    public double Maximum;

    public GreaterThenZeroValidator(double Maximum)
    {
        this.Maximum = Maximum;
    }

    public override bool IsValid(object? value)
    {
        var requestValue = value as double?;
        
        return requestValue < Maximum && requestValue >= Minimum;
    }
}