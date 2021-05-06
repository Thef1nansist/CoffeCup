using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Interfaces
{
    public interface ICoffeeHouseService
    {
        Task<CoffeeHouse> AddAsync(CoffeeHouse coffeeHouse);
        Task<IEnumerable<CoffeeHouse>> GetAsync();
        Task SellCoffeeItemAsync(int id);
        Task<IEnumerable<CoffeeHouse>> GetPopularCoffeeHouses();
    }
}
