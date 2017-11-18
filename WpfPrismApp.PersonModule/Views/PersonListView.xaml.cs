using System.Windows.Controls;
using WpfPrismApp.PersonModule.ViewModels;

namespace WpfPrismApp.PersonModule.Views
{
    /// <summary>
    /// Interaction logic for PersonListView
    /// </summary>
    public partial class PersonListView : UserControl
    {
        public PersonListView()
        {
            InitializeComponent();
        }

        private void PersonDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            (DataContext as PersonListViewModel).OnCellEditEnding();
        }
    }
}
