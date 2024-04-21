using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LightF_API.Helpers
{
    public class EmailOrBlankAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                if (string.IsNullOrEmpty(stringValue))
                {
                    return ValidationResult.Success;
                }

                if (!IsValidEmail(stringValue))
                {
                    return new ValidationResult(ErrorMessage ?? "Invalid email.");
                }
            }
            return ValidationResult.Success;
        }

        private bool IsValidEmail(string value)
        {
            return Regex.IsMatch(value, @"^$|^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
