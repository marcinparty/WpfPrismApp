using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfPrismApp.PersonModule.Models;

namespace WpfPrismApp.PersonModule.Services
{
    public interface IPersonService
    {
        ObservableCollection<Person> LoadPersonList();
        void SavePersonList(ObservableCollection<Person> list);
        int GetPersonListHashCode(IEnumerable<Person> list);
        bool ValidatePersonList(ObservableCollection<Person> list);
    }
}