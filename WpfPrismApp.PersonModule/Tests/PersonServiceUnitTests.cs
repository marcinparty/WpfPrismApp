using System;
using NUnit.Framework;
using WpfPrismApp.PersonModule.Models;
using WpfPrismApp.PersonModule.Services;

namespace WpfPrismApp.PersonModule.Tests
{
    public class PersonServiceUnitTests
    {
        [Test]
        public void IsValidErrorMessage_Equals_EmptyPersonErrorMessage()
        {
            // arrange
            var emptyPerson = new Person();
            var expectedErrorMessage = getExpectedErrorMessage();
            String errorMessage;

            // act
            PersonService.isValid(emptyPerson, out errorMessage);

            // asset
            Assert.AreEqual(expectedErrorMessage, errorMessage);
        }

        private String getExpectedErrorMessage()
        {
            return @"First name could not be empty.
Last name could not be empty.
Street name could not be empty.
House number could not be empty.
Postal code could not be empty.
Phone number could not be empty.
Date of birth could not be empty.
Age could not be empty.";
        }
    }
}
