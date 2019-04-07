
using System.Windows;
using Lab04.Managers;
using Lab04.Models;
using Lab04.Resources;

namespace Lab04
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            StorageManager.Initialize(new SerializedDataStorage());
            MainWindow mainWindow = new MainWindow();
            
            NavigationModel navigationModel = new NavigationModel(mainWindow);
            NavigationManager.Instance.Initialize(navigationModel);
            
            mainWindow.Show();
            navigationModel.Navigate(ViewsEnum.Table);
        }
    }
}
