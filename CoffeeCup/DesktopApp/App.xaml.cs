using DesktopApp.Interfaces;
using DesktopApp.Services;
using DesktopApp.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider _serviceProvider { get; set; }

        public IConfiguration _configuration { get; set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("CoffeeHouseApi", c =>
            {
                int.TryParse(_configuration.GetSection("Api:Timeout").Value, out var timeoutInSeconds);

                c.Timeout = new TimeSpan(0, 0, 0, timeoutInSeconds);
                c.BaseAddress = new Uri(_configuration.GetSection("Api:Url").Value);
            });

            services.AddSingleton(typeof(IAppUserService), typeof(AppUserService));
            services.AddSingleton(typeof(ICoffeeHouseService), typeof(CoffeeHouseService));
            services.AddSingleton(typeof(IFavoriteService), typeof(FavoriteService));
            services.AddSingleton(typeof(IConfiguration), _configuration);

            services.AddSingleton(typeof(MainWindow));
            services.AddSingleton(typeof(CoffeeHousesView));
        }
    }
}
