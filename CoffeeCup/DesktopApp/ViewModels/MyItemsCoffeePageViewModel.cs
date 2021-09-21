using DesktopApp.Commands;
using DesktopApp.Helper;
using DesktopApp.Models;
using DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.ViewModels
{
    public class MyItemsCoffeePageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CoffeeItem> coffeeItem;
        public ObservableCollection<CoffeeItem> CoffeeItem
        {
            get { return coffeeItem; }
            set
            {
                coffeeItem = value;
                OnPropertyChanged(nameof(CoffeeItem));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
