using System.Windows.Controls;
using System.Windows.Data;
using WpfPrismApp.PersonModule.Models;
using WpfPrismApp.PersonModule.Services;

namespace WpfPrismApp.PersonModule.Views
{
    public class PersonValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            Person person = (value as BindingGroup).Items[0] as Person;

            if (!PersonService.isValid(person, out var errorMessage))
                return new ValidationResult(false, errorMessage);

            return ValidationResult.ValidResult;
        }
    }
}