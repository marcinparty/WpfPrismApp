using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WpfPrismApp.PersonModule.Models
{
    [Serializable()]
    [XmlRoot(Namespace = "http://some/random/namespace/example", ElementName = "PersonList")]
    public class PersonList
    {
        public PersonList()
        {
            personCollection = new ObservableCollection<Person>();
        }

        public PersonList(ObservableCollection<Person> personCollection)
        {
            this.personCollection = personCollection;
        }

        [XmlElement("Person")]
        public ObservableCollection<Person> PersonCollection
        {
            get { return personCollection; }
            set { personCollection = value; }
        }

        private ObservableCollection<Person> personCollection;
    }

}
