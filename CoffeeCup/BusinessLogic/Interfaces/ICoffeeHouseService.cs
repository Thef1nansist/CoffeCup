using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICoffeeHouseService
    {
        Task<CoffeeHouse> AddAsync(CoffeeHouse item);
        Task<IEnumerable<CoffeeHouse>> GetAllAsync();
        Task<IEnumerable<CoffeeHouse>> GetAllAsync(string adminId);
        Task<IEnumerable<CoffeeHouse>> GetByCoffeHouseId(int coffeHouseId);
        Task<CoffeeHouse> GetByIdAsync(int id);
        Task<CoffeeHouse> UpdateAsync(CoffeeHouse item);
        Task SellCoffeeItemAsync(string userId, int id);
        Task<IEnumerable<CoffeeHouse>> GetPopularCoffeeHouses();
    }
}