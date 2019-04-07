
using System;
using System.Net.Mail;
using Lab04.Exceptions;
using Lab04.Managers;
using Lab04.Resources;
using Lab04.ViewModels;

namespace Lab04.Models
{
    class PersonModel
    {
        private Person _person;
        private readonly PersonViewModel _personViewModel;

        private readonly DateTime _periodFrom;
        

        public PersonModel(Person person , PersonViewModel personViewModel)
        {
            _person = person;
            _personViewModel = personViewModel;
            _periodFrom = new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        }

        internal bool ValidateInput(string selectedName, string selectedSurname, string selectedEmail, DateTime selectedDate , ViewsEnum mode)
        {
            try
            {
                ValidateDate(selectedDate);
                ValidateEmail(selectedEmail);

                _person = new Person(selectedName, selectedSurname, selectedEmail, selectedDate);

                switch (mode)
                {
                    case ViewsEnum.AddView:
                        StorageManager.DataStorage.AddPerson(_person);//Add person to serialized list
                        UpdateManager.Instance.AddPerson(_person);//Add person to current table
                        NavigationManager.Instance.Close(WindowsEnum.Person);
                        break;
                    case ViewsEnum.EditView:
                        StorageManager.DataStorage.DeletePerson(UpdateManager.Instance._tableViewModel.EditedPerson);//Add person to serialized list
                        StorageManager.DataStorage.AddPerson(_person);

                        UpdateManager.Instance._tableViewModel.PersonList.Remove(UpdateManager.Instance._tableViewModel
                            .EditedPerson);
                        UpdateManager.Instance.AddPerson(_person);//Add person to current table

                        NavigationManager.Instance.Close(WindowsEnum.Person);
                        break;
                    default:
                        throw new Exception("Proceed Mode Error");
                }

                return true;
            }
            catch (Exception e)
            {
                _personViewModel.ShowInvalidInputMessage(e);
                return false;
            }
        }

        private void ValidateDate(DateTime date)
        {
            if (date <= _periodFrom) throw new InvalidAgeException();

            if (date > DateTime.Now) throw new InvalidDateException();

        }

        private void ValidateEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

            }
            catch (FormatException)
            {
                throw new InvalidEmailException();

            }
        }
    }
}
