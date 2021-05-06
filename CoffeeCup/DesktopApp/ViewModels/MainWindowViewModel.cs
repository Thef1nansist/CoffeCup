using DesktopApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesktopApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private AppUser selectedAppUser;
        private ObservableCollection<AppUser> appUsers;

        public ObservableCollection<AppUser> AppUsers {
            get { return appUsers; }
            set
            {
                appUsers = value;
                OnPropertyChanged(nameof(AppUsers));
            }
        }

        public AppUser SelectedAppUser {
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
