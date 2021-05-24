using DesktopApp.Interfaces;
using DesktopApp.Models;
using DesktopApp.ViewModels;
using GMap.NET;
using GMap.NET.MapProviders;
using Microsoft.Azure.Search;
using Nest;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Maps.MapControl;

using System.Windows.Input;
using System.IO;
using System.Text.Json;

namespace DesktopApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MapPage.xaml
    /// </summary>
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
            //MyMap
            //GeoLocation geo = new GeoLocation();

        }

        //private void SearchAddress()
        //{

        //    string userIp = "127.0.0.1";
        //    string request = "http://dev.virtualearth.net/REST/v1/Locations?addressLine={searchfields.}&userLocation={userLocation}&userIp={userIp}&key={BingMapsKey}";
        //    string url = string.Format(request, Uri.EscapeDataString(searchfields.Text));

        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

        //    WebResponse response = req.GetResponse();

        //    Stream stream = response.GetResponseStream();

        //    StreamReader streamReader = new StreamReader(stream);

        //    string responsereader = streamReader.ReadToEnd();

        //    response.Close();

        //    JsonSerializer.Deserialize

        //    //GeoLocation nasd = new GeoLocation();


        //}

        //private string SearchKeywordLocation(string keywordLocation)
        //{
        //    String results = "";
        //    String key = "insert your Bing Maps key here";
        //    SearchRequest searchRequest = new SearchRequest();

        //    // Set the credentials using a valid Bing Maps key
        //    searchRequest.Credentials = new SearchService.Credentials();
        //    searchRequest.Credentials.ApplicationId = key;

        //    //Create the search query
        //    StructuredSearchQuery ssQuery = new StructuredSearchQuery();
        //    string[] parts = keywordLocation.Split(';');
        //    ssQuery.Keyword = parts[0];
        //    ssQuery.Location = parts[1];
        //    searchRequest.StructuredQuery = ssQuery;

        //    //Define options on the search
        //    searchRequest.SearchOptions = new SearchOptions();
        //    searchRequest.SearchOptions.Filters =
        //        new FilterExpression()
        //        {
        //            PropertyId = 3,
        //            CompareOperator = CompareOperator.GreaterThanOrEquals,
        //            FilterValue = 8.16
        //        };

        //    //Make the search request 
        //    SearchServiceClient searchService = new SearchServiceClient();
        //    SearchResponse searchResponse = searchService.Search(searchRequest);

        //    //Parse and format results
        //    if (searchResponse.ResultSets[0].Results.Length > 0)
        //    {
        //        StringBuilder resultList = new StringBuilder("");
        //        for (int i = 0; i < searchResponse.ResultSets[0].Results.Length; i++)
        //        {
        //            resultList.Append(String.Format("{0}. {1}\n", i + 1,
        //                searchResponse.ResultSets[0].Results[i].Name));
        //        }

        //        results = resultList.ToString();
        //    }
        //    else
        //        results = "No results found";

        //    return results;
        //}

    }
}
