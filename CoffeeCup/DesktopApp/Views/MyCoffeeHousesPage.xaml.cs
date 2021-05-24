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
    /// Логика взаимодействия для MyCoffeeHousesPage.xaml
    /// </summary>
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
