using DesktopApp.Interfaces;
using DesktopApp.Models;
using DesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegWindowCoffeeHouse.xaml
    /// </summary>
    public partial class RegWindowCoffeeHouse : Window
    {
        private readonly IAppUserService _userService;
        private readonly ICoffeeHouseService _coffeeHouseService;
        private readonly IFavoriteService _favoriteService;
        public RegWindowCoffeeHouse(IAppUserService userService, ICoffeeHouseService coffeeHouseService, IFavoriteService favoriteService)
        {
            _userService = userService;
            _coffeeHouseService = coffeeHouseService;
            InitializeComponent();

            DataContext = new RegWindowCoffeeHouseViewModel();
            _favoriteService = favoriteService;
        }

        private async void InitData(object sender, System.EventArgs e)
        {
            var users = await _userService.GetAsync();

            var dataContext = (RegWindowCoffeeHouseViewModel)DataContext;

            dataContext.AppUsers = new ObservableCollection<AppUser>(users);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if  (!ValidationReg(UserName.Text) || !ValidationReg(Password.Text) || UserName.Text.Length < 4 || Password.Text.Length < 4)
            {
                MessageBox.Show("Некорректное значение полей");
                return;
            }

            var asd = await _userService.CreateAsync(UserName.Text, Password.Text, CheckBox1.IsChecked.Value).ConfigureAwait(false);
            if (asd)
            {
                MessageBox.Show("Аккаунт создан!");

            }
            else
            {
                MessageBox.Show("Данный логин уже занят");
            }

        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mainwindow = new MainWindow(_userService, _coffeeHouseService, _favoriteService);
            mainwindow.Show();
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void X_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private bool ValidationReg(string str)
        {
            string patternW = @"\w+";
            if (!Regex.IsMatch(str, patternW, RegexOptions.IgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}
