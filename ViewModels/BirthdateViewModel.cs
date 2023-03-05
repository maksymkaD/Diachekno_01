using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Diachenko_01.Annotations;
//using Diachenko_01.Models;
using Diachenko_01.Tools;

namespace Diachenko_01.ViewModels
{
    struct User
    {
        public DateTime BirthDate;
        public string Age;
        public string ZodiacWest;
        public string ZodiacChina;
    }
    internal class BirthdateViewModel: INotifyPropertyChanged
    {
        #region Fields

        private static User _user;
        private RelayCommand<object> _analyzeDateCommand;
        #endregion

        #region Properties

        public DateTime Date
        {
            get => _user.BirthDate;
            set
            {
                _user.BirthDate = value;
                OnPropertyChanged();
            }
        }
        public string Age
        {
            get => $"Your age: {_user.Age} ";
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }

        public string ZodiacChina
        {
            get => $"Chinese zodiac: {_user.ZodiacChina}";
            set
            {
                _user.ZodiacChina = value;
                OnPropertyChanged();
            }
        }

        public string ZodiacWest
        {
            get => $"Western zodiac: {_user.ZodiacWest}";
            set
            {
                _user.ZodiacWest = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> AnalyzeDateCommand
        {
            get
            {
                return _analyzeDateCommand ??= new RelayCommand<object>(AnalyzeBirthDate);
            }
        }

        #endregion

        internal BirthdateViewModel()
        {
            _user = new User();
            Date = DateTime.Today;
        }
        private async void AnalyzeBirthDate(object o)
        {
           await Task.Run(() =>
            {
                try
                {
                    Age=CountAge();
                    ZodiacChina=GetZodiacChina();
                    ZodiacWest=GetZodiacWest();
                    CheckIfBirthday();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
        }
        private string CountAge()
        {
           DateTime today = DateTime.Today;
           int years = today.Year - Date.Year;
           if ((today.Month < Date.Month) || (today.Month == Date.Month && today.Day < Date.Day)) years-=1;
           if (years < 0) throw new ArgumentException("You are clearly lying regarding the birthdate. I don't believe you came from future!");
           if (years > 135) throw new ArgumentException("App is illegal for dudes older than 135");
           return years.ToString();
        }
        private string GetZodiacChina()
        {
            return (Date.Year % 12) switch
            {
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig",
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                11 => "Goat",
                _ => "Whoops, something's broken ;("
            };
        }

        private string GetZodiacWest()
        {
            int day = Date.Day;
            return Date.Month switch
            {
                1 => (day < 20 ? "Capricorn" : "Aquarius"),
                2 => (day < 19 ? "Aquarius" : "Pisces"),
                3 => (day < 21 ? "Pisces" : "Aries"),
                4 => (day < 20 ? "Aries" : "Taurus"),
                5 => (day < 21 ? "Taurus" : "Gemini"),
                6 => (day < 21 ? "Gemini" : "Cancer"),
                7 => (day < 23 ? "Cancer" : "Leo"),
                8 => (day < 23 ? "Leo" : "Virgo"),
                9 => (day < 23 ? "Virgo" : "Libra"),
                10 => (day < 23 ? "Libra" : "Scorpio"),
                11 => (day < 22 ? "Scorpio" : "Sagittarius"),
                _ => (day < 22 ? "Sagittarius" : "Capricorn")
            };
        }
        private void CheckIfBirthday()
        {
            if (DateTime.Today.Month == Date.Month && DateTime.Today.Day == Date.Day) MessageBox.Show("Happy b-day, my homie <3");
        }

        #region INotifyPropertyImplementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
