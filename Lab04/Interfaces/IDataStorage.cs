using Lab04.Models;
using System.Collections.Generic;

namespace Lab04.Interfaces
{
    interface IDataStorage
    {
        void AddPerson(Person person);
        void DeletePerson(Person person);
        void SaveChanges();
        List<Person> _personsList { get; }
    }
}
