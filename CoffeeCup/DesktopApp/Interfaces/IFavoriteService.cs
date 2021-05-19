using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> CreateFavoriteCoffeeHouse(AddFavoriteCoffeeHouse addModel);
        Task<IEnumerable<FavoriteCoffeeHouse>> GetFavoriteCoffeeHouses();
        IEnumerable<OrderedCoffee> GetOrderedCoffee();
    }
}
