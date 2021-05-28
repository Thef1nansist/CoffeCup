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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace DesktopApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddCoffeeHouse.xaml
    /// </summary>
    public partial class AddCoffeeHouse : Page
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        private readonly IAppUserService _appUserService;
        public AddCoffeeHouse(ICoffeeHouseService coffeeHouseService, IAppUserService appUserService)
        {
            InitializeComponent();
            _coffeeHouseService = coffeeHouseService;
            _appUserService = appUserService;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> listcoffeeitemsPrice = new List<string>();
            List<string> listcoffeeitems = new List<string>();
            List<string> listMainInform = new List<string>();

            listcoffeeitems.Add(CoffeeItem_1.Text);
            listcoffeeitems.Add(CoffeeItem_2.Text);
            listcoffeeitems.Add(CoffeeItem_3.Text);
            listcoffeeitems.Add(CoffeeItem_4.Text);
            listcoffeeitems.Add(CoffeeItem_4_Copy3.Text);
            listcoffeeitems.Add(CoffeeItem_4_Copy2.Text);
            listcoffeeitemsPrice.Add(Price_CoffeeItem_2.Text);
            listcoffeeitemsPrice.Add(Price_CoffeeItem_1.Text);
            listcoffeeitemsPrice.Add(Price_CoffeeItem_3.Text);
            listcoffeeitemsPrice.Add(Price_CoffeeItem_4.Text);
            listcoffeeitemsPrice.Add(Price_CoffeeItem_4_Copy2.Text);
            listcoffeeitemsPrice.Add(Price_CoffeeItem_4_Copy3.Text);
            listMainInform.Add(AddCoffeeHouseName.Text);
            listMainInform.Add(AddCoffeeHouseAddress.Text);
            if (!ValidationItemsCoffee(listcoffeeitems, 1) || !ValidationItemsCoffee(listcoffeeitemsPrice, 2))
            {
                MessageBox.Show("Некорректные данные в напитках");
                return;
            }

            if (!ValidationItemsCoffee(listMainInform, 3))
            {
                MessageBox.Show("Некорректные данные");
                return;
            }
            else if (img_path == null)
            {
                MessageBox.Show("You need to upload image first");
                return;
            }


            await _coffeeHouseService.AddAsync(new Models.CoffeeHouse()
            {
                CreatorId = _appUserService.UserId,
                Name = AddCoffeeHouseName?.Text,
                Address = AddCoffeeHouseAddress?.Text,
                ImageSource = img_path,

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
                    },
                    new Models.CoffeeItem()
                    {
                        Name = CoffeeItem_4_Copy2.Text,
                        Price = Decimal.Parse(Price_CoffeeItem_4_Copy2.Text)
                    },
                    new Models.CoffeeItem()
                    {
                        Name = CoffeeItem_4_Copy3.Text,
                        Price = Decimal.Parse(Price_CoffeeItem_4_Copy3.Text)
                    }

                }
            });
            ; ;
            MessageBox.Show("Готово");

            this.Content = null;
        }
        private bool ValidationItemsCoffee(List<string> item, int number)
        {
            string patternW = @"\w+";
            string patternD = @"\d+";
            if (number == 1)
            {
                foreach (string str in item)
                {
                    if (!Regex.IsMatch(str, patternW, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                }
            }
            else if (number == 2)
            {
                foreach (string str in item)
                {
                    if (!Regex.IsMatch(str, patternD, RegexOptions.IgnoreCase) || Double.Parse(str) <= 0)
                    {
                        return false;
                    }
                }
            }
            else if (number == 3)
            {
                foreach (string str in item)
                {
                    if (!Regex.IsMatch(str, patternW, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void CoffeeItem_2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private string img_path;
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var openFileDialog = new OpenFileDialog();

                openFileDialog.Title = "Select a picture";
                openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                     "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                     "Portable Network Graphic (*.png)|*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    imgCompany.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    img_path = openFileDialog.FileName;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Картинка не смогла загрузится, попробуйте заново");
            }
           
        }
    }
}
