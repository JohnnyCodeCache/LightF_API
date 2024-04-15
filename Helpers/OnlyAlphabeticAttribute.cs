using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LightF_API.Helpers
{
    public class OnlyAlphabeticAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                if (!IsAlphabetic(stringValue))
                {
                    return new ValidationResult(ErrorMessage ?? "The field must contain only alphabetic characters.");
                }
            }
            return ValidationResult.Success;
        }

        private bool IsAlphabetic(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }
    }
}
