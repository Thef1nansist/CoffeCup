using Azure.Core;
using DesktopApp.Interfaces;
using DesktopApp.Models;
using DesktopApp.ViewModels;
using DesktopApp.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAppUserService _userService;
        private readonly ICoffeeHouseService _coffeeHouseService;
        private readonly IFavoriteService _favoriteService;

        public string AppID { get; set; }
        public string AccessToken { get; set; }

        public MainWindow(IAppUserService userService, ICoffeeHouseService coffeeHouseService, IFavoriteService favoriteService)
        {
            _userService = userService;
            _coffeeHouseService = coffeeHouseService;

            InitializeComponent();

            DataContext = new MainWindowViewModel();
            _favoriteService = favoriteService;
        }
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            webBrowser.Navigate(new Uri("https://www.facebook.com/v10.0/dialog/oauth?client_id=444634286758743&redirect_uri=https://www.facebook.com/connect/login_success.html&state=123"));
        }
        private void webBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            webBrowser.Visibility = Visibility.Visible;

            AccessToken = e.Uri.Fragment.Split('&')[0].Replace("#access_token=", "");
        }

        private async void InitData(object sender, System.EventArgs e)
        {
            var users = await _userService.GetAsync();

            var dataContext = (MainWindowViewModel)DataContext;

            dataContext.AppUsers = new ObservableCollection<AppUser>(users);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!ValidationLog(UserName.Text) && !ValidationLog(Password.Password))
            {
                MessageBox.Show("Неверный логин/пароль");
                return;
            }
            var result = await _userService.LoginAsync(UserName.Text, Password.Password);

            if (result.Item1)
            {
                if (result.Item2)
                {
                    var coffehousemw = new CoffeeHouseMainWindow(_coffeeHouseService, _userService, _favoriteService);
                    coffehousemw.Show();
                    this.Close();
                }
                else
                {
                    var dashboard = new Dashboard(_coffeeHouseService, _userService, _favoriteService);
                    dashboard.Show();
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Неверный логин/пароль");
            }

        }

        private bool ValidationLog(string str)
        {
            string patternW = @"\w+";
            if (!Regex.IsMatch(str, patternW, RegexOptions.IgnoreCase))
            {
                return false;
            }
            return true;
        }

        private void RegPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var regWindow = new RegWindowCoffeeHouse(_userService, _coffeeHouseService,_favoriteService);
            regWindow.Show();
            this.Hide();
        }
    }
}
