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
using System.Windows.Shapes;

namespace DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for PopularCoffeeHouses.xaml
    /// </summary>
    public partial class PopularCoffeeHouses : Window
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
