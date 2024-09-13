using System.ComponentModel.DataAnnotations;

namespace ToDoAppMVC.Validations
{
    public class FirstLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var firstLetter = value.ToString()[0].ToString();
            if (firstLetter.ToUpper().Equals(firstLetter))
            {
                return ValidationResult.Success;

            }
            return new ValidationResult("La primera letra debe ser mayuscula");
        }
    }
}
