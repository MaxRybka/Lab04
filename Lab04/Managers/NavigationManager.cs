
using Lab04.Models;
using Lab04.Resources;

namespace Lab04.Managers
{
    class NavigationManager
    {
        private static NavigationManager _instance;
        private static object _lock = new object();
        private NavigationModel _navigationModel;

        public static NavigationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    {
                        lock (_lock)
                        {
                            _instance = new NavigationManager();
                            
                        }
                    }
                }

                return _instance;
            }
        }

        public void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        public void Close(WindowsEnum window)
        {
            _navigationModel?.Close(window);
        }

        public void Navigate(ViewsEnum view)
        {
            _navigationModel?.Navigate(view);
        }

    }
}
