using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IFavoriteService
    {
        Task<Favorite> AddAsync(Favorite item);
        Task<IEnumerable<Favorite>> GetAll(string userId);
        Task<IEnumerable<Favorite>> GetByCoffeHouseId(int coffeHouseId);
        Task<Favorite> GetByIdAsync(int id);
        Task<IEnumerable<Favorite>> GetByUserId(string userId);
        Task<Favorite> UpdateAsync(Favorite item);
        IEnumerable<Infrastructure.Models.OrderedCoffee> GetOrderedCoffee(string userId);
    }
}