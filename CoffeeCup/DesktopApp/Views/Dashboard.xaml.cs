using DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DesktopApp.Views
{
    public partial class Dashboard : Window
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        private readonly IAppUserService _appUserService;
        private readonly IFavoriteService _favoriteService;

        public Dashboard(ICoffeeHouseService coffeeHouseService, IAppUserService appUserService, IFavoriteService favoriteService)
        {
            _coffeeHouseService = coffeeHouseService;
            InitializeComponent();
            _appUserService = appUserService;
            _favoriteService = favoriteService;
        }
        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CoffeeHousesView coffeeHouses = new CoffeeHousesView(_coffeeHouseService, _appUserService, _favoriteService);
          LoadWindowNew(coffeeHouses);
        }

        private void ListViewItem_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var popular = new PopularCoffeeHouses(_coffeeHouseService);
            LoadWindowNew(popular);
        }

        private void ListViewItem_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            var favoriteCoffeeHousesPage = new FavoriteCoffeeHouses(_favoriteService, _appUserService);
            LoadWindowNew(favoriteCoffeeHousesPage);
        }
        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void LoadWindowNew(Page pageToLoad)
        {
            MainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            MainFrame.Content = pageToLoad;
        }
        private void Image_MouseDown_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();

        }
        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AboutDevelopersPage aboutDevelopersPage = new AboutDevelopersPage();
            LoadWindowNew(aboutDevelopersPage);
        }
        private async void ListViewItem_MouseEnter_3(object sender, MouseButtonEventArgs e)
        {
            var userStatistics = new UserStatistics(_favoriteService);
            LoadWindowNew(userStatistics);
        }
        private void StackPanel_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MapPage mapPage = new MapPage(_coffeeHouseService);
            LoadWindowNew(mapPage);

        }
        private void StackPanel_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            MyItemsCoffeePage myItemsCoffeePage = new MyItemsCoffeePage(_coffeeHouseService, _appUserService);
            LoadWindowNew(myItemsCoffeePage);
        }
    }
}
