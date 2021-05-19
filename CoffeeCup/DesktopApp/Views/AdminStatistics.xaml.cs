using DesktopApp.Interfaces;
using DesktopApp.Models;
using LiveCharts;
using LiveCharts.Wpf;
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

namespace DesktopApp.Views
{
    public class CoffeeKeyValue
    {
        public string Name;
        public int Value;
    }
    /// <summary>
    /// Логика взаимодействия для AdminStatistics.xaml
    /// </summary>
    public partial class AdminStatistics : Page
    {
        private IEnumerable<CoffeeHouse> coffeeHouses;
        private IAppUserService AppUserService;
        public ICoffeeHouseService CoffeeHouseService { get; }
        public AdminStatistics(IAppUserService appUserService, ICoffeeHouseService coffeeHouseService)
        {
            InitializeComponent();
            CoffeeHouseService = coffeeHouseService;
            AppUserService = appUserService;
            SetupStatistics();

        }
        public async void SetupStatistics()
        {
            coffeeHouses = await CoffeeHouseService.GetAsync(AppUserService.UserId);
            SetBarGraph();
            SetRounderChart();
        }
        public async void SetBarGraph()
        {
            var solds = new List<CoffeeKeyValue>();

            foreach (var house in coffeeHouses)
            {
                foreach (var coffee in house.CoffeeItems)
                {
                    solds.Add(new CoffeeKeyValue { Name = coffee.Name, Value = coffee.SoldCounter });
                }
            }
            BarGraph.Series = new SeriesCollection();
            var series = new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(solds.Select(x => x.Value).ToArray())
            };
            BarGraph.Series.Add(series);
        }
        public async void SetRounderChart()
        {
            var piechart = new SeriesCollection();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})",
                chartPoint.Y, chartPoint.Participation);
            foreach (var house in coffeeHouses)
            {
                foreach (var coffee in house.CoffeeItems)
                {
                    piechart.Add(
                        new PieSeries
                        {
                            Title = coffee.Name,
                            Values = new ChartValues<int> { coffee.SoldCounter },
                            DataLabels = true,
                            LabelPoint = labelPoint
                        });
                }
            }
            rounder.Series = piechart;
        }
    }
}
