using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildYourOwnObservableObject.ViewModels
{
    internal class UserInfoViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;


        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public UserInfoViewModel()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    FirstName = new Random().Next(1, 1000).ToString();
                    Debug.WriteLine($"FirstName: {FirstName}");
                    Debug.WriteLine($"LastName: {LastName}");
                    Debug.WriteLine($"FullName: {FullName}");
                    Thread.Sleep(500);
                }
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
