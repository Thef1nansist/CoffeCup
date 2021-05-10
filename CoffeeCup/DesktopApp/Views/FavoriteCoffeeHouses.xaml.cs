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
    /// Логика взаимодействия для FavoriteCoffeeHouses.xaml
    /// </summary>
    public partial class FavoriteCoffeeHouses : Page
    {
        private readonly IAppUserService _appUserService;
        private readonly IFavoriteService _favoriteService;

        public FavoriteCoffeeHouses(IFavoriteService favoriteService, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _favoriteService = favoriteService;
            InitializeComponent();
            DataContext = new FavoriteCoffeeHouseViewModel();
        }

        private async void GetFavoriteCoffeeHouses(object sender, System.EventArgs e)
        {
            var favorites = await _favoriteService.GetFavoriteCoffeeHouses();
            var dataContext = (FavoriteCoffeeHouseViewModel)DataContext;

            dataContext.FavoriteCoffeeHouses = new ObservableCollection<FavoriteCoffeeHouse>(favorites);
            listOfFavoriteCoffeeHouses.ItemsSource = dataContext.FavoriteCoffeeHouses;
        }
    }
}
