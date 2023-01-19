using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildYourOwnObservableObject.ViewModels
{
    internal class UserInfoViewModel
    {
        public string FirstName { get; set; }

        public UserInfoViewModel()
        {
            Task.Run(() => { 
                while(true)
                {
                    FirstName = new Random().Next(1, 1000).ToString();
                    Debug.WriteLine($"FirstName: {FirstName}");
                    Thread.Sleep(500);
                }
            });
        }
    }
}
