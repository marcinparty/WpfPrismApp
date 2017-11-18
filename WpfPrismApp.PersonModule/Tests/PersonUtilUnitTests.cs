using System;
using NUnit.Framework;
using WpfPrismApp.PersonModule.Utils;

namespace WpfPrismApp.PersonModule.Tests
{
    public class PersonUtilUnitTests
    {
        [Test]
        public void GetAge_LessThen_BirthDate()
        {
            // arrange
            var age = 10;
            DateTime dayBeforeBirthDate = DateTime.Today.AddYears(-age).AddDays(-1);
            DateTime birthDate = DateTime.Today.AddYears(-age);
            DateTime dayAfterBirthDate = DateTime.Today.AddYears(-age).AddDays(1);

            // act
            var dayBeforeAge = PersonUtil.GetAge(dayBeforeBirthDate);
            var birthDayAge = PersonUtil.GetAge(birthDate);
            var dayAfterAge = PersonUtil.GetAge(dayAfterBirthDate);

            // asset
            Assert.AreEqual(dayBeforeAge, age);
            Assert.AreEqual(birthDayAge, age);
            Assert.Less(dayAfterAge, age);
        }
    }
}
