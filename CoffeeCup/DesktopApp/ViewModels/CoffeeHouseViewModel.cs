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
    public class CoffeeHouseViewModel : INotifyPropertyChanged
    {
        private CoffeeHouse selectedCoffeeHouse;
        private ObservableCollection<CoffeeHouse> coffeeHouses;

        public ObservableCollection<CoffeeHouse> CoffeeHouses
        {
            get { return coffeeHouses; }
            set
            {
                coffeeHouses = value;
                OnPropertyChanged(nameof(CoffeeHouses));
            }
        }
        public CoffeeHouse SelectedCoffeeHouse
        {
            get { return selectedCoffeeHouse; }
            set
            {
                selectedCoffeeHouse = value;
                OnPropertyChanged(nameof(SelectedCoffeeHouse));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
