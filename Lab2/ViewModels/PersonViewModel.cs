using Lab2.Models;
using Lab2.Views;
using System;
using System.Threading;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Lab2.ViewModels
{
    public class PersonViewModel
    {
        private Person _person;
        private RelayCommand<object> _proceedCommand;

        #region Properties
        public string Name
        {
            get; set;
        }
        public string Surname
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public DateTime BirthDate
        {
            get; set;
        }

        public string Age
        {
            get
            {
                if (_person == null) return "";
                return _person.Age + " y.o.";
            }
        }

        public string SunSign
        {
            get
            {
                if (_person == null) return "";
                return _person.SunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                if (_person == null) return "";
                return _person.ChineseSign;
            }
        }

        public string IsAdult
        {
            get
            {
                if (_person == null) return "";
                else if (_person.Age >= 18) return "adult";
                else return "child";
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (_person == null) return false;
                else if (_person.BirthDate.Day.Equals(DateTime.Now.Day)
                    && _person.BirthDate.Month.Equals(DateTime.Now.Month)) return true;
                else return false;
            }
        }

        public string Date
        {
            get
            {
                if (_person == null) return "";
                else return _person.BirthDate.ToShortDateString();
            }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                _proceedCommand = new RelayCommand<object>(_ => Proceed(), CanExecute);
                return _proceedCommand;
            }
        }
        #endregion

        // initializes person and starts a new window
        private void Proceed()
        {
            _person = new Person(Name, Surname, Email, BirthDate);
            if (_person.Age > 135 || _person.BirthDate.CompareTo(DateTime.Today) > 0)
                MessageBox.Show("Your date is incorrect. Try again!", "Error");
            else
            {
                InformationWindow w = new InformationWindow(this);
                Thread.Sleep(2000);
                w.Show();
                if (IsBirthday)
                {
                    MessageBox.Show("Happy Birthday!", "Message");
                }
            }
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(Name)
               && !String.IsNullOrWhiteSpace(Surname)
               && !String.IsNullOrWhiteSpace(Email)
               && !(BirthDate.Equals(DateTime.MinValue));
        }

    }
}
