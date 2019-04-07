using Lab04.Resources;
using Lab04.Tools;
using System;
using System.Windows;

namespace Lab04.Models
{
    
    class Person : ObservableItem
    {

        public readonly PersonData _personData;

        public string Name
        {
            get
            {
                return _personData._name;
            }
            set
            {
                 _personData._name = value;
                
            }
        }

        public string Surname
        {
            get
            {
                return _personData._surname;
            }
            set
            {
                _personData._surname = value;
                
            }
        }

        public string Email
        {
            get
            {
                return _personData._email;
            }
            set
            {
                _personData._email = value;
                
            }
        }

       
        public DateTime BornDateTime
        {
            get
            {
                return _personData._bornDateTime;

            }
        }

        public string IsAdult
        {
            get
            {
                return  _personData._isAdult ? "yes" : "no";
            }
        }

        public string SunSign
        {
            get
            {
                return _personData._sunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _personData._chineseSign;
            }
        }

        public string IsBirthday
        {
            get
            {
                return _personData._isBirthday ? "yes" : "no";
            }
        }



        public Person() { }

        public Person(string firstName, string secondName, string email, DateTime bornDateTime)
        {
            _personData = new PersonData(firstName, secondName, email, bornDateTime, 
                CalculateAge(bornDateTime) > 18 , CalculateChineseSign(bornDateTime) , CalculateSunSign(bornDateTime) , CalculateBirthday(bornDateTime));

        }

        public Person(PersonData personData)
        {
            _personData = personData;
    
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            return age;
        }

        private string CalculateChineseSign(DateTime dateOfBirth)
        {
            return ((ChineseSigns)(dateOfBirth.Date.Year % 12)).GetDescription();
        }

        private string CalculateSunSign(DateTime dateOfBirth)
        {
            switch (dateOfBirth.Date.Month)
            {
                case 1:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Capricorn.GetDescription() : SunSigns.Aquarius.GetDescription();
                case 2:
                    return (dateOfBirth.Date.Day <= 19) ? SunSigns.Aquarius.GetDescription() : SunSigns.Pisces.GetDescription();
                case 3:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Pisces.GetDescription() : SunSigns.Aries.GetDescription();
                case 4:
                    return (dateOfBirth.Date.Day <= 20) ? SunSigns.Aries.GetDescription() : SunSigns.Taurus.GetDescription();
                case 5:
                    return (dateOfBirth.Date.Day <= 21) ? SunSigns.Taurus.GetDescription() : SunSigns.Gemini.GetDescription();
                case 6:
                    return (dateOfBirth.Date.Day <= 21) ? SunSigns.Gemini.GetDescription() : SunSigns.Cancer.GetDescription();
                case 7:
                    return (dateOfBirth.Date.Day <= 22) ? SunSigns.Cancer.GetDescription() : SunSigns.Leo.GetDescription();
                case 8:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Leo.GetDescription() : SunSigns.Virgo.GetDescription();
                case 9:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Virgo.GetDescription() : SunSigns.Libra.GetDescription();
                case 10:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Libra.GetDescription() : SunSigns.Scorpio.GetDescription();
                case 11:
                    return (dateOfBirth.Date.Day <= 22) ? SunSigns.Scorpio.GetDescription() : SunSigns.Sagittarius.GetDescription();
                case 12:
                    return (dateOfBirth.Date.Day <= 23) ? SunSigns.Sagittarius.GetDescription() : SunSigns.Capricorn.GetDescription();
                default:
                    return String.Empty;
            }

        }

        private bool CalculateBirthday(DateTime dateOfBirth)
        {
            return DateTime.Now.Day == dateOfBirth.Day && DateTime.Now.Month == dateOfBirth.Month;
        }


    }
}
