using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LightF_API.Helpers
{
    public class PhoneNumberOrBlankAttribute : ValidationAttribute
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

                if (!IsValidPhoneNumber(stringValue))
                {
                    return new ValidationResult(ErrorMessage ?? "Invalid phone number format. 212-555-1234 is valid.");
                }
            }
            return ValidationResult.Success;
        }

        private bool IsValidPhoneNumber(string value)
        {
            // Match the format "222-222-2222"
            return Regex.IsMatch(value, @"^\d{3}-\d{3}-\d{4}$");
        }
    }
}
