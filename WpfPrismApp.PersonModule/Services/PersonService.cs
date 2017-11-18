using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using WpfPrismApp.PersonModule.Models;
using WpfPrismApp.PersonModule.Utils;

namespace WpfPrismApp.PersonModule.Services
{
    public class PersonService : IPersonService
    {
        public ObservableCollection<Person> LoadPersonList()
        {
            return XmlSerializerUtil.DeserializeFromFile<PersonList>(GetOrCreateDatabaseFile().FullName).PersonCollection;
        }

        public void SavePersonList(ObservableCollection<Person> list)
        {
            XmlSerializerUtil.SerializeToFile(new PersonList(list), GetOrCreateDatabaseFile().FullName);
        }

        public int GetPersonListHashCode(IEnumerable<Person> list)
        {
            return XmlSerializerUtil.SerializeToString(list).GetHashCode();
        }

        public bool ValidatePersonList(ObservableCollection<Person> list)
        {
            foreach (var person in list)
            {
                if (!PersonService.isValid(person, out var errorMessage))
                    return false;
            }

            return true;
        }
        
        public static bool isValid(Person person, out String outputErrorMessage)
        {
            StringBuilder messageBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(person.FirstName))
                messageBuilder.AppendLine("First name could not be empty.");

            if (String.IsNullOrEmpty(person.LastName))
                messageBuilder.AppendLine("Last name could not be empty.");

            if (String.IsNullOrEmpty(person.StreetName))
                messageBuilder.AppendLine("Street name could not be empty.");

            if (String.IsNullOrEmpty(person.HouseNumber))
                messageBuilder.AppendLine("House number could not be empty.");

            if (String.IsNullOrEmpty(person.PostalCode))
                messageBuilder.AppendLine("Postal code could not be empty.");

            if (String.IsNullOrEmpty(person.PhoneNumber))
                messageBuilder.AppendLine("Phone number could not be empty.");

            if (!person.DayOfBirth.HasValue || String.IsNullOrEmpty(person.DayOfBirth.ToString()))
                messageBuilder.AppendLine("Date of birth could not be empty.");

            if (person.DayOfBirth.HasValue && person.DayOfBirth.Value > DateTime.Now.Date)
                messageBuilder.AppendLine("Date of birth is from future.");

            if (String.IsNullOrEmpty(person.Age))
                messageBuilder.AppendLine("Age could not be empty.");

            outputErrorMessage = messageBuilder.ToString().Trim();

            return String.IsNullOrEmpty(outputErrorMessage);
        }

        private FileInfo GetOrCreateDatabaseFile()
        {
            if (!Directory.Exists(fileDirectory))
                Directory.CreateDirectory(fileDirectory);

            var file = new FileInfo(fileDirectory + fileName);

            if (!file.Exists)
                XmlSerializerUtil.SerializeToFile(new PersonList(), file.FullName);

            return file;
        }
        
        private readonly string fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\WpfPrismApp\\";
        private readonly string fileName = "PersonList.xml";
    }
}
