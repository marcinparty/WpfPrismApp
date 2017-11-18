using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Prism.Mvvm;
using WpfPrismApp.PersonModule.Utils;

namespace WpfPrismApp.PersonModule.Models
{
    [DataContract]
    public class Person : BindableBase
    {
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                this.firstName = value;
                OnPropertyChanged(() => FirstName);
            }
        }

        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set
            {
                this.lastName = value;
                OnPropertyChanged(() => LastName);
            }
        }

        [DataMember]
        public string StreetName
        {
            get { return streetName; }
            set
            {
                this.streetName = value;
                OnPropertyChanged(() => StreetName);
            }
        }

        [DataMember]
        public string HouseNumber
        {
            get { return houseNumber; }
            set
            {
                this.houseNumber = value;
                OnPropertyChanged(() => HouseNumber);
            }
        }

        [DataMember]
        public string ApartmentNumber
        {
            get { return apartmentNumber; }
            set {
                this.apartmentNumber = value;
                OnPropertyChanged(() => ApartmentNumber);
            }
        }

        [DataMember]
        public string PostalCode
        {
            get { return postalCode; }
            set {
                this.postalCode = value;
                OnPropertyChanged(() => PostalCode);
            }
        }

        [DataMember]
        [Required]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set {
                this.phoneNumber = value;
                OnPropertyChanged(() => PhoneNumber);
            }
        }

        [DataMember]
        public DateTime? DayOfBirth
        {
            get { return dayOfBirth; }
            set
            {
                this.dayOfBirth = value;
                OnPropertyChanged(() => DayOfBirth);
                OnPropertyChanged(() => Age);
            }
        }

        [DataMember]
        public string Age
        {
            get
            {
                int? tmpAge = PersonUtil.GetAge(dayOfBirth);
                return tmpAge.HasValue ? tmpAge.Value.ToString() : String.Empty;
            }
            set
            {
                this.age = value;
                OnPropertyChanged(() => Age);
            }
        }

        private string firstName;
        private string lastName;
        private string streetName;
        private string houseNumber;
        private string apartmentNumber;
        private string postalCode;
        private string phoneNumber;
        private DateTime? dayOfBirth;
        private string age;
    }
}
