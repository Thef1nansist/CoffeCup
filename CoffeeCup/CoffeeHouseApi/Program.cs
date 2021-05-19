using Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoffeeHouseApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<Infrastructure.Contexts.CoffeeCupContext>()
                .UseSqlite("DataSource=coffeeHouse.db")
                .Options;
            var context = new Infrastructure.Contexts.CoffeeCupContext(options);
            //if (context.Database.EnsureCreated())
            {
                //var users = context.Users.ToList();
                //var a = users.ToArray();
                //var coffehouse = context.CoffeeHouses.ToList();
                //var b = coffehouse.ToArray();
            }
            //var users = context.Users.ToList();
            //var user = users[0];
            //var admin = users[1];
            //var coff = new CoffeeHouse();
            //coff.
            //var coffeeHouse = new CoffeeHouse
            //{
            //    CreatorId = admin.Id,
            //    Name = "Pure",
            //    Address = "city Amuera",
            //    Creator = admin,
            //    CoffeeItems = new List<CoffeeItem>
            //        {
            //            new CoffeeItem
            //            {
            //                Name = "Coffee",
            //                Price = 10,
            //                SoldCounter = 5
            //            },
            //            new CoffeeItem
            //            {
            //                Name = "Tea",
            //                Price = 15,
            //                SoldCounter = 2
            //            },
            //            new CoffeeItem
            //            {
            //                Name = "Cola",
            //                Price = 7,
            //                SoldCounter = 15
            //            },
            //        }
            //};
            //context.CoffeeHouses.Add(coffeeHouse);
            //context.SaveChanges();
            //var orderedCoffee = new OrderedCoffee
            //{
            //    UserId = user.Id,
            //    User = user,
            //    Coffee = coffeeHouse.CoffeeItems.Last(),
            //    CoffeeId = coffeeHouse.CoffeeItems.Last().Id
            //};
            //context.OrderedCoffees.Add(orderedCoffee);
            //context.SaveChanges();
            
                        CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
