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
    public class FavoriteCoffeeHouseViewModel : INotifyPropertyChanged
    {
        private FavoriteCoffeeHouse selectedFavoriteCoffeeHouse;
        private ObservableCollection<FavoriteCoffeeHouse> favoriteCoffeeHouses;

        public ObservableCollection<FavoriteCoffeeHouse> FavoriteCoffeeHouses
        {
            get { return favoriteCoffeeHouses; }
            set
            {
                favoriteCoffeeHouses = value;
                OnPropertyChanged(nameof(FavoriteCoffeeHouses));
            }   
        }
        public FavoriteCoffeeHouse SelectedFavoriteCoffeeHouse
        {
            get { return selectedFavoriteCoffeeHouse; }
            set
            {
                selectedFavoriteCoffeeHouse = value;
                OnPropertyChanged(nameof(SelectedFavoriteCoffeeHouse));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
