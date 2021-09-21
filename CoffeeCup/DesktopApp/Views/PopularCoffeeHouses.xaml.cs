using DesktopApp.Interfaces;
using DesktopApp.Models;
using DesktopApp.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace DesktopApp.Views
{
    public partial class PopularCoffeeHouses : Page
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        public PopularCoffeeHouses(ICoffeeHouseService coffeeHouseService)
        {
            _coffeeHouseService = coffeeHouseService;
            InitializeComponent();
            DataContext = new PopularCoffeeHousesViewModel();
        }
        private async void GetPopularCoffeeHouses(object sender, System.EventArgs e)
        {
            var coffeeHouses = await _coffeeHouseService.GetPopularCoffeeHouses();
            var dataContext = (PopularCoffeeHousesViewModel)DataContext;

            dataContext.CoffeeHouses = new ObservableCollection<CoffeeHouse>(coffeeHouses);
            listOfPopularCoffeeHouses.ItemsSource = dataContext.CoffeeHouses;
        }
    }
}
