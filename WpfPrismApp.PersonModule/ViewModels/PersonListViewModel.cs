using System;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfPrismApp.PersonModule.Models;
using WpfPrismApp.PersonModule.Services;

namespace WpfPrismApp.PersonModule.ViewModels
{
    public class PersonListViewModel : BindableBase
    {
        public PersonListViewModel(IPersonService personService)
        {
            this.personService = personService;

            ViewLoadedCommand = new DelegateCommand(() => { ObservablePersonList = personService.LoadPersonList(); });
            RemoveRowCommand = new DelegateCommand<object>(p => { ObservablePersonList.Remove((Person)p); });
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public ICommand ViewLoadedCommand { get; private set; }
        public ICommand RemoveRowCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public ObservableCollection<Person> ObservablePersonList
        {
            get
            {
                return this.personList;
            }
            set
            {
                personList.CollectionChanged -= OnPersonListCollectionChanged;

                if (personList != value)
                    personList = value;

                personListHashCode = personService.GetPersonListHashCode(personList);
                PersonListChanged = false;
                personList.CollectionChanged += OnPersonListCollectionChanged;
                OnPropertyChanged(() => ObservablePersonList);
            }
        }

        public bool PersonListChanged
        {
            get { return personListChanged; }
            set
            {
                personListChanged = value;
                OnPropertyChanged(() => PersonListChanged);
            }
        }

        public void OnCellEditEnding()
        {
            CheckListChanged();
        }
        
        private void OnPersonListCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CheckListChanged();
        }

        private void Save()
        {
            if (!personService.ValidatePersonList(personList))
            {
                MessageBox.Show("Validation failed. Check your person list.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            personService.SavePersonList(personList);
            personListHashCode = personService.GetPersonListHashCode(personList);
            PersonListChanged = false;
            MessageBox.Show("Saving completed", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel()
        {
            if (MessageBox.Show("Cancel changes?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.No)
                ObservablePersonList = personService.LoadPersonList();
        }

        private void CheckListChanged()
        {
            PersonListChanged = !personListHashCode.Equals(personService.GetPersonListHashCode(personList));
            CommandManager.InvalidateRequerySuggested();
        }

        private readonly IPersonService personService;
        private ObservableCollection<Person> personList = new ObservableCollection<Person>();
        private int personListHashCode;
        private bool personListChanged;
    }

    public class NullToCollapseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as Person == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
