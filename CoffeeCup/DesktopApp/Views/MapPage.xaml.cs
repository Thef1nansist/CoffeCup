using DesktopApp.Interfaces;
using DesktopApp.Models;
using DesktopApp.ViewModels;
using GMap.NET;
using GMap.NET.MapProviders;
using Microsoft.Azure.Search;
using Nest;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Maps.MapControl;

using System.Windows.Input;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Nancy.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.Maps.MapControl.WPF;

namespace DesktopApp.Views
{
    public partial class MapPage : System.Windows.Controls.Page
    {
        private readonly ICoffeeHouseService _coffeeHouseService;
        public MapPage(ICoffeeHouseService coffeeHouseService)
        {
            _coffeeHouseService = coffeeHouseService;
            InitializeComponent();
            DataContext = new CoffeeHouseViewModel();
        }
        private async void GetCoffeeHouses(object sender, System.EventArgs e)
        {
            var coffeehouses = await _coffeeHouseService.GetAsync();
            var datacontext = (CoffeeHouseViewModel)DataContext;
            datacontext.CoffeeHouses = new ObservableCollection<CoffeeHouse>(coffeehouses);
            listOfCoffeeHouses.ItemsSource = datacontext.CoffeeHouses;

        }
        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                listOfCoffeeHouses.IsEnabled = false;
                //string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();

                var BingMapKey = "8itKXGuCRC7wS5Qw8k2x~By6Q1BWVISQE_9H4UUhAVw~AldAIdhET4LGLlf-O5ASFlU5DxHCJrB5EDQVqwy2hCl3E1MQTgM46BaviDCFnwsV";

                string mapAddr = ((sender as StackPanel).Children[(sender as StackPanel).Children.Count - 1] as TextBlock).Text;

                string request = $"http://dev.virtualearth.net/REST/v1/Locations?addressLine={mapAddr}&key={BingMapKey}";
                string url = string.Format(request, Uri.EscapeDataString(searchfields.Text));

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                WebResponse response = req.GetResponse();

                Stream stream = response.GetResponseStream();

                StreamReader streamReader = new StreamReader(stream);

                string responsereader = streamReader.ReadToEnd();

                JObject obj = JObject.Parse(responsereader);
                double longitude = (double)obj["resourceSets"][0]["resources"][0]["point"]["coordinates"][0];
                double latitude = (double)obj["resourceSets"][0]["resources"][0]["point"]["coordinates"][1];
                Location location = new Location(longitude, latitude);
                MyMap.SetView(location, 20);
                canvasMarker.SetValue(MapLayer.PositionProperty, location);

                response.Close();
                listOfCoffeeHouses.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Карта обновляется, зайдите позже");
                listOfCoffeeHouses.IsEnabled = true;
            }

        }


    }
 
}
