using Lab04.Interfaces;
using Lab04.Models;
using Lab04.Managers;
using Lab04.Tools;
using System.Collections.Generic;
using System.IO;

namespace Lab04.Resources
{
    class SerializedDataStorage : IDataStorage
    {
        public List<Person> _personsList { get; private set; }
        

        internal SerializedDataStorage()
        {
            try
            {
                Transform(SerializationManager.Deserialize<List<PersonData>>(FileHelper.StorageFilePath));

            }
            catch (FileNotFoundException)
            {
                _personsList = new List<Person>();
                for (int i = 1; i < 10; i++)
                {
                    _personsList.Add(new Person("Volodymyr", "Osadchuk", "vovavov04@gmail.com",
                        new System.DateTime(2000, 8, 4)));
                    _personsList.Add(new Person("Andrey", "Olekseev", "andrey@ukr.net",
                        new System.DateTime(2004, 2, 13)));
                    _personsList.Add(new Person("Vasya", "Kobelev", "vasil@gmail.com",
                        new System.DateTime(1989, 8, 18)));
                    _personsList.Add(new Person("Misha", "Stasuk", "statuk@gmail.com",
                        new System.DateTime(2012, 1, 21)));
                    _personsList.Add(new Person("Kyrylo", "Andonik", "abcd@mail.ru",
                        new System.DateTime(2001, 7, 9)));

                }


                SaveChanges();
                
            }
        }

        private void Transform(List<PersonData> list)
        {
            _personsList = new List<Person>();
            foreach(PersonData p in list)
            {
                _personsList.Add(new Person(p));
            }
        }

        private List<PersonData> Transform(List<Person> list)
        {
            List<PersonData> personDataList = new List<PersonData>();

            foreach (Person p in list)
            {
                personDataList.Add(p._personData);
            }

            return personDataList;
        }

        public void AddPerson(Person person)
        {
            _personsList.Add(person);
            SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _personsList.Remove(person);
            SaveChanges();
        }

        

        public void SaveChanges()
        {
            
            SerializationManager.Serialize(Transform(_personsList), FileHelper.StorageFilePath);
        }

    }
}
