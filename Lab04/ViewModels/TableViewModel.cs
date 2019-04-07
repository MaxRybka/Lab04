
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Lab04.Managers;
using Lab04.Models;
using Lab04.Resources;
using Lab04.Tools;

namespace Lab04.ViewModels
{
    class TableViewModel : ObservableItem
    {
        public Person SelectedPerson { private get; set; }
        public Person EditedPerson {  get; private set; }

        private RelayCommand<object> _addNewPersonCommand;
        private RelayCommand<object> _editPersonCommand;
        private ICommand _deletePersonCommand;

        


        private ObservableCollection<Person> _personList;

        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set { ChangeAndNotify(ref _personList, value, () => PersonList); }
        }

        public void AddPerson(Person person)
        {
            PersonList.Add(person);
            SortPersonsList(SortBy);
        }

        public TableViewModel()
        {
            PersonList = new ObservableCollection<Person>(StorageManager.DataStorage._personsList);
            
            FilterField = SortBy =String.Empty;
            FiltrBy = "System.Windows.Controls.ComboBoxItem: Name";
        }

       
        public RelayCommand<object> AddNewPersonCommand
        {
            get
            {
                return _addNewPersonCommand ?? (_addNewPersonCommand = new RelayCommand<object>(
                           o => NavigationManager.Instance.Navigate(ViewsEnum.AddView)));
            }
        }

        public RelayCommand<object> EditPersonCommand
        {
            get
            {
                
                return _editPersonCommand ?? (_editPersonCommand = new RelayCommand<object>(
                           o => {
                               if (SelectedPerson != null)
                               {
                                   EditedPerson = SelectedPerson;
                                   NavigationManager.Instance.Navigate(ViewsEnum.EditView);
                                   
                               }
                               else
                                   MessageBox.Show("Nothing to edit!");
                           }));
            }
        }

        public ICommand DeletePersonCommand
        {
            get
            {
                return _deletePersonCommand ?? (_deletePersonCommand = new RelayCommand<object>(
                           o =>
                           {
                               if (SelectedPerson != null)
                               {
                                   StorageManager.DataStorage.DeletePerson(SelectedPerson);
                                   PersonList.Remove(SelectedPerson);
                               }
                               else
                                   MessageBox.Show("Nothing to delete!");
                           }));
            }
        }

        
        private string _sortBy;

        public string SortBy
        {
            get
            {
                return _sortBy;
            }
            set
            {
                SortPersonsList(_sortBy = value);
            }
        }

        private void SortPersonsList(string sortBy)
        {

            List<Person> personsList = PersonList.ToList();
            IOrderedEnumerable<Person> sortedPersons = null;

            switch (sortBy)
            {
                case "System.Windows.Controls.ComboBoxItem: Name":
                    sortedPersons = from p in personsList
                                    orderby p.Name
                                    select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Surname":
                    sortedPersons = from p in personsList
                                    orderby p.Surname
                                    select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Email":
                    sortedPersons = from p in personsList
                                    orderby p.Email
                                    select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: BirthDay":
                    sortedPersons = from p in personsList
                                    orderby p.BornDateTime
                                    select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: IsAdult":
                    sortedPersons = from p in personsList
                                    orderby p.IsAdult
                                    select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: SunSign":
                    sortedPersons = from p in personsList
                                    orderby p.SunSign
                                    select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: ChineseSign":
                    sortedPersons = from p in personsList
                                    orderby p.ChineseSign
                                    select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: IsBirthday":
                    sortedPersons = from p in personsList
                                    orderby p.IsBirthday
                                    select p;
                    break;
            }

            
            if (sortedPersons != null)
            {
               
                PersonList.Clear();
                foreach (Person p in sortedPersons)
                    PersonList.Add(p);
               
            }
        }


        private string _filtrBy;
        public string FiltrBy
        {
            get
            {
                return _filtrBy;
            }
            set
            {
                FiltrPersonsList(FilterField, _filtrBy = value);
            }
        }

        private string _filterField;
        public string FilterField
        {
            private get
            {
                return _filterField;
            }
            set
            {
                FiltrPersonsList(_filterField = value, FiltrBy);
            }
        }

        private void FiltrPersonsList(string text, string filtrBy)
        {
            text = text.ToLower();
            var personsList = StorageManager.DataStorage._personsList;
            IEnumerable<Person> filteredPersons = null;

            switch (filtrBy)
            {
                case "System.Windows.Controls.ComboBoxItem: Name":
                    filteredPersons = from p in personsList
                                      where p.Name.ToLower().Contains(text)
                                      select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Surname":
                    filteredPersons = from p in personsList
                                      where p.Surname.ToLower().Contains(text)
                                      select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Email":
                    filteredPersons = from p in personsList
                                      where p.Email.ToLower().Contains(text)
                                      select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: BirthDay":
                    filteredPersons = from p in personsList
                                      where p.BornDateTime.ToString().ToLower().Contains(text)
                                      select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: IsAdult":
                    filteredPersons = from p in personsList
                                      where p.IsAdult.ToString().Contains(text)
                                      select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: SunSign":
                    filteredPersons = from p in personsList
                                      where p.SunSign.ToLower().Contains(text)
                                      select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: ChineseSign":
                    filteredPersons = from p in personsList
                                      where p.ChineseSign.ToLower().Contains(text)
                                      select p;
                    break;
                case "System.Windows.Controls.ComboBoxItem: IsBirthday":
                    filteredPersons = from p in personsList
                                      where p.IsBirthday.ToString().Contains(text)
                                      select p;
                    break;
            }

            if (filteredPersons != null)
            {
                PersonList.Clear();
                foreach (Person p in filteredPersons)
                    PersonList.Add(p);
            }
           
        }



    }
}
