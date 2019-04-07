
using Lab04.Models;
using Lab04.ViewModels;
using System.Windows.Controls;
using Lab04.Resources;

namespace Lab04.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {

        private PersonViewModel _personViewModel;

        internal PersonView(Person person , ViewsEnum mode)
        {
            InitializeComponent();
            _personViewModel = new PersonViewModel(person , mode);
            DataContext = _personViewModel;
        }

        public PersonView()
        {
            InitializeComponent();
            _personViewModel = new PersonViewModel();
            DataContext = _personViewModel;
        }


    }
}

