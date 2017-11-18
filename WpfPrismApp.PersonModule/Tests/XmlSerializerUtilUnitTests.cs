using System;
using System.Collections.ObjectModel;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using WpfPrismApp.PersonModule.Models;
using WpfPrismApp.PersonModule.Utils;

namespace WpfPrismApp.PersonModule.Tests
{
    public class XmlSerializerUtilUnitTests
    {
        [Test]
        public void SerializeToString_Equals_StringAfterSerialization()
        {
            // arrange
            var expectedString = getTestXmlArrayString();

            // act
            var serializedList = XmlSerializerUtil.SerializeToString(getTestPersonList().PersonCollection);

            // asset
            Assert.AreEqual(expectedString, serializedList);
        }

        [Test]
        public void SerializeToFile_Equals_DeserializeFromFile()
        {
            // arrange
            var tmpFilePath = Path.Combine(Environment.CurrentDirectory, "PersonList.xml");
            var expectedList = getTestPersonList();

            //String expectedString = getTestXmlArrayString();

            // act
            XmlSerializerUtil.SerializeToFile(expectedList, tmpFilePath);
            var deserializePersonList = XmlSerializerUtil.DeserializeFromFile<PersonList>(tmpFilePath);

            // asset
            Assert.IsTrue(File.Exists(tmpFilePath));
            deserializePersonList.ShouldBeEquivalentTo(expectedList);

            // clean
            File.Delete(tmpFilePath);
        }

        private PersonList getTestPersonList()
        {

            return new PersonList()
            {
                PersonCollection = new ObservableCollection<Person>
                {
                    new Person
                    {
                        FirstName="Marcin",
                        LastName ="Partyka",
                        StreetName ="Ulica",
                        HouseNumber ="8",
                        ApartmentNumber ="3",
                        PostalCode ="60-041",
                        PhoneNumber ="500-666-666",
                        DayOfBirth = new DateTime(1981, 8, 21),
                        Age = "36"
                    },
                    new Person
                    {
                        FirstName="Jan",
                        LastName ="Kowalski",
                        StreetName ="Błotna",
                        HouseNumber ="Zachlapany",
                        ApartmentNumber ="",
                        PostalCode ="61-688",
                        PhoneNumber ="600-555-555",
                        DayOfBirth = new DateTime(2017, 11, 18),
                        Age = "0"
                    }
                }
            };
        }

        private string getTestXmlArrayString()
        {
            return @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfPerson xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <Person>
    <FirstName>Marcin</FirstName>
    <LastName>Partyka</LastName>
    <StreetName>Ulica</StreetName>
    <HouseNumber>8</HouseNumber>
    <ApartmentNumber>3</ApartmentNumber>
    <PostalCode>60-041</PostalCode>
    <PhoneNumber>500-666-666</PhoneNumber>
    <DayOfBirth>1981-08-21T00:00:00</DayOfBirth>
    <Age>36</Age>
  </Person>
  <Person>
    <FirstName>Jan</FirstName>
    <LastName>Kowalski</LastName>
    <StreetName>Błotna</StreetName>
    <HouseNumber>Zachlapany</HouseNumber>
    <ApartmentNumber />
    <PostalCode>61-688</PostalCode>
    <PhoneNumber>600-555-555</PhoneNumber>
    <DayOfBirth>2017-11-18T00:00:00</DayOfBirth>
    <Age>0</Age>
  </Person>
</ArrayOfPerson>";
        }
    }
}
