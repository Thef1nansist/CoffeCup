using DesktopApp.Interfaces;
using DesktopApp.Models;
using DesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CoffeeHousesView.xaml
    /// </summary>
    public partial class CoffeeHousesView : Page
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        private readonly IAppUserService _appUserService;
        private readonly IFavoriteService _favoriteService;
        public CoffeeHousesView(ICoffeeHouseService coffeeHouseService, IAppUserService appUserService, IFavoriteService favoriteService)
        {
            _coffeeHouseService = coffeeHouseService;
            _appUserService = appUserService;
            _favoriteService = favoriteService;
            InitializeComponent();
            DataContext = new CoffeeHouseViewModel();
        }

        private async void GetCoffeeHouses(object sender, System.EventArgs e)
        {
            var coffeeHouses = await _coffeeHouseService.GetAsync();
            var dataContext = (CoffeeHouseViewModel)DataContext;

            dataContext.CoffeeHouses = new ObservableCollection<CoffeeHouse>(coffeeHouses);
            listOfCoffeeHouses.ItemsSource = dataContext.CoffeeHouses;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = (CoffeeHouseViewModel)DataContext;

            await _favoriteService
                .CreateFavoriteCoffeeHouse(new AddFavoriteCoffeeHouse()
                {
                    CoffeeHouseId = context.SelectedCoffeeHouse.Id,
                    UserId = _appUserService.UserId
                });
        }
        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).Tag;
            var coffeeHouseId = ((CoffeeHouseViewModel)DataContext).SelectedCoffeeHouse.Id;
            await _coffeeHouseService.SellCoffeeItemAsync(id);
        }
    }
}
