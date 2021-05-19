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
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        private readonly IAppUserService _appUserService;
        private readonly IFavoriteService _favoriteService;

        private static bool flagOpOrCl = false;
        private static bool flagFotMenu = false;

        public Dashboard(ICoffeeHouseService coffeeHouseService, IAppUserService appUserService, IFavoriteService favoriteService)
        {
            _coffeeHouseService = coffeeHouseService;
            InitializeComponent();
            _appUserService = appUserService;
            _favoriteService = favoriteService;
        }

      

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var addPage = new AddCoffeeHouse(_coffeeHouseService);
        //    addPage.Show();
        //}
     

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
        private void Image_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            this.WindowState = WindowState.Maximized;
            cryl1.Visibility = Visibility.Collapsed;
            cryl2.Visibility = Visibility.Visible;
            btAbout.Margin = new Thickness(0, 150, 0, 0);
            flagFotMenu = true;
            ButtonMenu.Margin = new Thickness(250, 0, 0, 0);
            FooterMenu.Margin = new Thickness(250, 0, 0, 0);
            GridMenu.Width = 250;
            FooterMenu.Width = ActualWidth - 250;
            flagOpOrCl = false;
        }

        private void cryl2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            cryl1.Visibility = Visibility.Visible;
            cryl2.Visibility = Visibility.Collapsed;
            btAbout.Margin = new Thickness(0, 72, 0, 0);
            ButtonMenu.Margin = new Thickness(250, 0, 0, 0);
            FooterMenu.Margin = new Thickness(250, 0, 0, 0);
            GridMenu.Width = 250;
            FooterMenu.Width = 750;
            flagOpOrCl = false;
            flagFotMenu = false;
        }
        private void LoadWindowNew(Page pageToLoad)
        {
            MainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            MainFrame.Content = pageToLoad;
        }

        private void PackIcon_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (flagOpOrCl == false)
            {
                GridMenu.Width = 52;
                ButtonMenu.Margin = new Thickness(60, 0, 0, 0);
                flagOpOrCl = true;
                FooterMenu.Margin = new Thickness(50, 0, 0, 0);
                FooterMenu.Width = ActualWidth - 50;
            }
            else
            {
                ButtonMenu.Margin = new Thickness(250, 0, 0, 0);
                FooterMenu.Margin = new Thickness(250, 0, 0, 0);
                GridMenu.Width = 250;
                flagOpOrCl = false;
                if (flagFotMenu == false)
                    FooterMenu.Width = 750;
                else
                    FooterMenu.Width = ActualWidth - 250;


            }
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
    }
}
