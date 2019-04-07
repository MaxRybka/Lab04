using Lab04.Interfaces;

namespace Lab04.Managers
{
    class StorageManager
    {
        internal static IDataStorage DataStorage { get; private set; }

        internal static void Initialize(IDataStorage dataStorage)
        {
            DataStorage = dataStorage;
        }
    }
}
