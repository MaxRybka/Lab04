using Lab04.Models;
using Lab04.ViewModels;


namespace Lab04.Managers
{
    class UpdateManager
    {
        private static UpdateManager _instance;
        private static object _lock = new object();
        public TableViewModel _tableViewModel { get; private set; }

        public static UpdateManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    {
                        lock (_lock)
                        {
                            _instance = new UpdateManager();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Initialize(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;
        }

        public void AddPerson(Person person)
        {
            _tableViewModel.AddPerson(person);
        }
    }
}
