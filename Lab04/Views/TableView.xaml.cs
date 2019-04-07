using System.Windows.Controls;
using Lab04.Managers;
using Lab04.ViewModels;

namespace Lab04.Views
{
    /// <summary>
    /// Логика взаимодействия для TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {

        private TableViewModel _tableViewModel;

        public TableView()
        {
            InitializeComponent();
            _tableViewModel = new TableViewModel();

            UpdateManager.Instance.Initialize(_tableViewModel);

            DataContext = _tableViewModel;
        }
    }
}
