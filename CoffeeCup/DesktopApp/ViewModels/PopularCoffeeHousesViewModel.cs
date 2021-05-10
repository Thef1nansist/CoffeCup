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
    public class PopularCoffeeHousesViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<CoffeeHouse> coffeeHouses;

        public ICommand NextPage { get; set; }
        public ICommand PreviousPage { get; set; }

        public Paging PagingVar { get; set; }
        public ObservableCollection<CoffeeHouse> CoffeeHouses
        {
            get { return coffeeHouses; }
            set
            {
                coffeeHouses = value;
                OnPropertyChanged(nameof(CoffeeHouses));
            }
        }

        

        public PopularCoffeeHousesViewModel()
        {
            NextPage = new NextPagePopularHousesCommand(this);
        }
        public void GoToNextPage()
        {
            //PagingVar.CurrentPage++;
            //OnPropertyChanged("PagingVar");
            //CakeList =
            //OnPropertyChanged("CakeList");

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
