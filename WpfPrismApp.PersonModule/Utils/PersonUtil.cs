using System;

namespace WpfPrismApp.PersonModule.Utils
{
    class PersonUtil
    {
        public static int? GetAge(DateTime? birthDate)
        {
            if (!birthDate.HasValue)
                return null;

            var today = DateTime.Today;
            var age = today.Year - birthDate.Value.Year;
            if (birthDate > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
