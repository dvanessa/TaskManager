using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TaskManager.Application.Validations
{
    public class NoNumbersAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string str && Regex.IsMatch(str, @"\d"))
            {
                return new ValidationResult("El título no debe contener números.");
            }

            return ValidationResult.Success;
        }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.UtcNow;
            }
            return true; // Ignorar si no hay valor (usa [Required] si es obligatorio)
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} debe ser una fecha futura.";
        }
    }
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly string _startProperty;
        private readonly string _endProperty;

        public DateRangeAttribute(string startProperty, string endProperty)
        {
            _startProperty = startProperty;
            _endProperty = endProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var startProp = validationContext.ObjectType.GetProperty(_startProperty);
            var endProp = validationContext.ObjectType.GetProperty(_endProperty);

            if (startProp == null || endProp == null)
                return new ValidationResult($"Propiedades no válidas: {_startProperty}, {_endProperty}");

            var startValue = (DateTime?)startProp.GetValue(validationContext.ObjectInstance);
            var endValue = (DateTime?)endProp.GetValue(validationContext.ObjectInstance);

            if (startValue.HasValue && endValue.HasValue && startValue > endValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}