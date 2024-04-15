using Sollicitatieproef.Core.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace Sollicitatieproef.Core.Models.CustomValidators.GebruikerViewModelValidators;

public class UserRightsAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var rechten = (IReadOnlyList<RechtViewModel>)value!;

        if (!rechten.Any(r => r.IsToegekend))
        {
            return new ValidationResult("Gelieve minimaal één recht in te selecteren.");
        }

        return ValidationResult.Success;
    }
}
