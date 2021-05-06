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
    /// Interaction logic for AddCoffeeHouse.xaml
    /// </summary>
    public partial class AddCoffeeHouse : Window
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        public AddCoffeeHouse(ICoffeeHouseService coffeeHouseService)
        {
            InitializeComponent();
            _coffeeHouseService = coffeeHouseService;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _coffeeHouseService.AddAsync(new Models.CoffeeHouse()
            {
                Name = AddCoffeeHouseName?.Text,
                Address = AddCoffeeHouseAddress?.Text,
                CoffeeItems = new List<Models.CoffeeItem>()
                {
                    new Models.CoffeeItem()
                    {
                        Name = CoffeeItem_1.Text,
                        Price = Decimal.Parse(Price_CoffeeItem_1.Text)
                    },
                    new Models.CoffeeItem()
                    {
                        Name = CoffeeItem_2.Text,
                        Price = Decimal.Parse(Price_CoffeeItem_2.Text)
                    },
                    new Models.CoffeeItem()
                    {
                        Name = CoffeeItem_3.Text,
                        Price = Decimal.Parse(Price_CoffeeItem_3.Text)
                    },
                    new Models.CoffeeItem()
                    {
                        Name = CoffeeItem_4.Text,
                        Price = Decimal.Parse(Price_CoffeeItem_4.Text)
                    }
                }
            });
            this.Close();
        }

        private void CoffeeItem_1_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
