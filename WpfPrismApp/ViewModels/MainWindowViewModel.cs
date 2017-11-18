using Prism.Mvvm;

namespace BasicRegionNavigation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string title = "WpfPrismApp";
    }
}
