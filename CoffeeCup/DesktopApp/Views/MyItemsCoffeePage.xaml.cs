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
    /// Логика взаимодействия для MyItemsCoffeePage.xaml
    /// </summary>
    public partial class MyItemsCoffeePage : Page
    {
        private readonly ICoffeeHouseService _coffeeHouseService;

        private readonly IAppUserService _appUserService;
        public MyItemsCoffeePage(ICoffeeHouseService coffeeHouseService, IAppUserService appUserService)
        {
            _coffeeHouseService = coffeeHouseService;
            _appUserService = appUserService;
            InitializeComponent();
            DataContext = new MyItemsCoffeePageViewModel();
        }

        private async void GetCoffeeItemByUserAsync(object sender, System.EventArgs e)
        {

            var coffeeItems = await _coffeeHouseService.GetCoffeeItemByUserAsync(_appUserService.UserId);
            var dataContext = (MyItemsCoffeePageViewModel)DataContext;

            dataContext.CoffeeItem = new ObservableCollection<CoffeeItem>(coffeeItems);
            listItemCourse.ItemsSource = dataContext.CoffeeItem;
        }
    }
}
