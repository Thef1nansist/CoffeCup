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
    /// Логика взаимодействия для CoffeeHouseMainWindow.xaml
    /// </summary>
    public partial class CoffeeHouseMainWindow : Window
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        private readonly IAppUserService _appUserService;
        private readonly IFavoriteService _favoriteService;
        public CoffeeHouseMainWindow(ICoffeeHouseService coffeeHouseService, IAppUserService appUserService, IFavoriteService favoriteService)
        {
            _coffeeHouseService = coffeeHouseService;
            InitializeComponent();

            _appUserService = appUserService;
            _favoriteService = favoriteService;
        }

        private void Popularbt_Click(object sender, RoutedEventArgs e)
        {
            var popular = new PopularCoffeeHouses(_coffeeHouseService);
            popular.Show();
        }

        private void AddCoffeeHouses_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddCoffeeHouse addCoffee = new AddCoffeeHouse(_coffeeHouseService);
            LoadWindowNew(addCoffee);
            
        }

        private void LoadWindowNew(Page pageToLoad)
        {
            NewAddCompany.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            NewAddCompany.Content = pageToLoad;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
