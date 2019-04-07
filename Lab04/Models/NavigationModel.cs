using System;
using Lab04.Managers;
using Lab04.Resources;
using Lab04.Views;
using Lab04.Windows;

namespace Lab04.Models
{

    class NavigationModel
    {
        private MainWindow _mainWindow;
        private PersonWindow _personWindow;
        private TableView _tableView;
        private PersonView _personView;



        public NavigationModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _personWindow = new PersonWindow();
            _tableView = new TableView();
            _personView = new PersonView();
        }

        public void Navigate(ViewsEnum view)
        {
            switch (view)
            {
                case ViewsEnum.Table:

                    _mainWindow.ContentControl.Content = _tableView;
                    break;
                case ViewsEnum.AddView:

                    if (!_personWindow.IsActive)
                    {
                        
                        _personWindow = new PersonWindow();
                        _personWindow.Show();
                        _personWindow.ContentControl.Content = _personView;
                    
                    }

                    break;
                case ViewsEnum.EditView:

                    if (!_personWindow.IsActive && (UpdateManager.Instance._tableViewModel.EditedPerson != null))
                    {

                        _personWindow = new PersonWindow();
                 
                        _personView = new PersonView(UpdateManager.Instance._tableViewModel.EditedPerson , ViewsEnum.EditView);
                        _personWindow.ContentControl.Content = _personView;
                        _personWindow.Show();

                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(view), view, null);
            }
        }

        public void Close(WindowsEnum window)
        {
            switch (window)
            {
                case WindowsEnum.Main:

                    _mainWindow.Close();
                    break;
                case WindowsEnum.Person:

                   _personWindow.Close();
                   break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(window), window, null);
            }
        }

    }
}
