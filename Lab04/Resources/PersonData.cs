using System;

namespace Lab04.Resources
{
    [Serializable]
    public class PersonData
    {
        public string _name { get; set; }
        public string _surname { get; set; }
        public string _email { get; set; }
        public DateTime _bornDateTime { get; set; }

        public bool _isAdult { get; set; }
        public bool _isBirthday { get; set; }
        public string _chineseSign { get; set; }
        public string _sunSign { get; set; }

        internal PersonData(string name, string surname, string email, DateTime bornDateTime, bool isAdult,
            string chineaseSign, string sunSign, bool isBirthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _bornDateTime = bornDateTime;

            _isAdult = isAdult;
            _chineseSign = chineaseSign;
            _sunSign = sunSign;
            _isBirthday = isBirthday;
        }

    }
}
