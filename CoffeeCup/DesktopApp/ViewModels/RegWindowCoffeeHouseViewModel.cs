using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ViewModels
{
   public class RegWindowCoffeeHouseViewModel : INotifyPropertyChanged
    {
        private AppUser selectedAppUser;
        private ObservableCollection<AppUser> appUsers;
        public ObservableCollection<AppUser> AppUsers
        {
            get { return appUsers; }
            set
            {
                appUsers = value;
                OnPropertyChanged(nameof(AppUsers));
            }
        }
        public AppUser SelectedAppUser
        {
            get { return selectedAppUser; }
            set
            {
                selectedAppUser = value;
                OnPropertyChanged(nameof(SelectedAppUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}

