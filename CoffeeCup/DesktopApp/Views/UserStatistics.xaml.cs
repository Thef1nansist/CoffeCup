using DesktopApp.Interfaces;
using DesktopApp.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace DesktopApp.Views
{
    public partial class UserStatistics : Page
    {

        public IFavoriteService IFavoriteService { get; }
        public IEnumerable<OrderedCoffee> OrderedCoffees { get; set; }
        public UserStatistics(IFavoriteService iFavoriteService)
        {
            InitializeComponent();
            IFavoriteService = iFavoriteService;
            SetupStatistics();
        }

        public void SetupStatistics()
        {
            OrderedCoffees = IFavoriteService.GetOrderedCoffee();
            SetBarGraph();
            SetRounderChart();
        }
        public async void SetBarGraph()
        {
            var solds = new Dictionary<string, int>();

            foreach (var ordered in OrderedCoffees)
            {
                if (!solds.ContainsKey(ordered.Coffee.Name))
                {
                    solds.Add(ordered.Coffee.Name, OrderedCoffees.Count(x =>
                        x.Coffee.Name == ordered.Coffee.Name));
                }
            }
            var series = new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(solds.Values)
            };
            BarGraph.Series = new SeriesCollection();
            BarGraph.Series.Add(series);
        }
        public async void SetRounderChart()
        {
            var piechart = new SeriesCollection();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})",
                chartPoint.Y, chartPoint.Participation);

            var orders = new Dictionary<string, int>();

            foreach (var ordered in OrderedCoffees)
            {
                if (!orders.ContainsKey(ordered.Coffee.Name))
                {
                    orders.Add(ordered.Coffee.Name, OrderedCoffees.Count(x =>
                        x.Coffee.Name == ordered.Coffee.Name));
                }
            }
            foreach (var coffee in orders)
            {
                piechart.Add(
                    new PieSeries
                    {
                        Title = coffee.Key,
                        Values = new ChartValues<int> { coffee.Value },
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });
            }
            rounder.Series = piechart;
        }
    }
}
