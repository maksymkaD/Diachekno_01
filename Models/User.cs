using System;

namespace Diachenko_01.Models
{
    internal class User
    {
        private DateTime _birthDate;
        private string _age;
        private string _zodiacWest;
        private string _zodiacChina;
        private string _zodiacPersonality;

        #region Properties

        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public string Age
        {
            get => _age;
            set => _age = value;
        }

        public string WesternZodiac
        {
            get => _zodiacWest;
            set => _zodiacWest = value;
        }

        public string ChineseZodiac
        {
            get => _zodiacChina;
            set => _zodiacChina = value;
        }
        public string ZodiacPersonality
        {
            get => _zodiacPersonality;
            set => _zodiacPersonality = value;
        }
        #endregion
    }
}