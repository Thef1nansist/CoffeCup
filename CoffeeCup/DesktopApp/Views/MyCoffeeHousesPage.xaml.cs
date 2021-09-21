using DesktopApp.Interfaces;
using DesktopApp.Models;
using DesktopApp.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;


namespace DesktopApp.Views
{
    public partial class MyCoffeeHousesPage : Page
    {
        ICoffeeHouseService  _coffeeHouseService;
        public MyCoffeeHousesPage(ICoffeeHouseService coffeeHouseService)
        {
            _coffeeHouseService = coffeeHouseService;
            InitializeComponent();
            DataContext = new MyCoffeeHousesViewModel();
        }
        private async void GetByCoffeeHousesIdUser(object sender, System.EventArgs e)
        {
            var coffeeHouses = await _coffeeHouseService.GetByCoffeeHousesIdUser();
            var dataContext = (MyCoffeeHousesViewModel)DataContext;

            dataContext.CoffeeHouses = new ObservableCollection<CoffeeHouse>(coffeeHouses);
            listOfPopularCoffeeHouses.ItemsSource = dataContext.CoffeeHouses;
        }
    }
}
