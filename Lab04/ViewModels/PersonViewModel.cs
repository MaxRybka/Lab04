

using Lab04.Models;
using Lab04.Tools;
using System;
using System.Windows;
using System.Windows.Input;
using Lab04.Resources;

namespace Lab04.ViewModels
{
    class PersonViewModel : ObservableItem
    {

        private DateTime _selectedDate = DateTime.Now;
        private String _selectedName = String.Empty;
        private String _selectedSurname = String.Empty;
        private String _selectedEmail = String.Empty;

        private readonly PersonModel _personModel;
        private ICommand _confirmCommand;

        private readonly ViewsEnum _mode = ViewsEnum.AddView; // adding mode by default

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { ChangeAndNotify(ref _selectedDate, value, () => SelectedDate); }
        }

        public string SelectedName
        {
            get { return _selectedName; }
            set { ChangeAndNotify(ref _selectedName, value, () => SelectedName); }
        }

        public string SelectedSurname
        {
            get { return _selectedSurname; }
            set { ChangeAndNotify(ref _selectedSurname, value, () => SelectedSurname); }
        }

        public string SelectedEmail
        {
            get { return _selectedEmail; }
            set { ChangeAndNotify(ref _selectedEmail, value, () => SelectedEmail); }
        }

        public PersonViewModel(Person person , ViewsEnum mode)
        {
            _personModel = new PersonModel(person , this);

            SelectedName = person.Name;
            SelectedSurname = person.Surname;
            SelectedEmail = person.Email;
            SelectedDate = person.BornDateTime;

            _mode = mode;
        }

        public PersonViewModel()
        {
            _personModel = new PersonModel(new Person(), this);
        }

        public void ShowInvalidInputMessage(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }


        public ICommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand<object>(StartExecute, StartCanExecute);
                }

                return _confirmCommand;
            }
            set { ChangeAndNotify(ref _confirmCommand, value, () => ConfirmCommand); }
        }

        private void StartExecute(object obj)
        {
            _personModel.ValidateInput(SelectedName, SelectedSurname, SelectedEmail, SelectedDate , _mode);

        }

        private bool StartCanExecute(object obj)
        {
            return (!string.IsNullOrWhiteSpace(_selectedName) && !string.IsNullOrWhiteSpace(_selectedSurname) && !string.IsNullOrWhiteSpace(_selectedEmail));
        }

    }
}
