using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAM = Infrastructure.Models;

namespace BusinessLogic.Services
{
    public class CoffeeHouseService : ICoffeeHouseService
    {
        private readonly IDbContextFactory<CoffeeCupContext> _contextFactory;
        private readonly IMapper _mapper;

        public CoffeeHouseService(IDbContextFactory<CoffeeCupContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }


        public async Task<CoffeeHouse> AddAsync(CoffeeHouse item)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var map = _mapper.Map<DAM.CoffeeHouse>(item);
                var entityDa = await context.CoffeeHouses
                    .AddAsync(map)
                    .ConfigureAwait(false);

                await context.SaveChangesAsync().ConfigureAwait(false);

                return _mapper.Map<CoffeeHouse>(entityDa.Entity);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }
        public async Task<List<CoffeeItem>> GetCoffeeItemByUserAsync(string userId)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var coffeeItems = await context.OrderedCoffees
                    .Include(x => x.Coffee)
                    .Where(x => x.UserId == userId)
                    .Select(x => x.Coffee)
                    .ToListAsync()
                    .ConfigureAwait(false);

                return _mapper.Map<List<CoffeeItem>>(coffeeItems);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }
        public async Task<CoffeeHouse> UpdateAsync(CoffeeHouse item)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.CoffeeHouses
                .FirstOrDefaultAsync(i => i.Id == item.Id)
                .ConfigureAwait(false);

            if (entity != null)
            {
                var itemNew = _mapper.Map(item, entity);

                context.CoffeeHouses.Update(itemNew);
            }
            await context.SaveChangesAsync().ConfigureAwait(false);

            return _mapper.Map<CoffeeHouse>(entity);
        }

        public async Task<CoffeeHouse> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.CoffeeHouses
                .AsNoTracking()
                .Include(x => x.CoffeeItems)
                .FirstOrDefaultAsync(i => i.Id == id)
                .ConfigureAwait(false);

            return _mapper.Map<CoffeeHouse>(entity);
        }
        public async Task<IEnumerable<CoffeeHouse>> GetByCoffeHouseId(int coffeHouseId)
        {
            using var context = _contextFactory.CreateDbContext();

            var entities = await context.CoffeeHouses
                .Where(item => item.Id == coffeHouseId)
                .Include(x => x.CoffeeItems)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<CoffeeHouse>>(entities);
        }

        public async Task<IEnumerable<CoffeeHouse>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext(); //для работы с любыми данными юзать using

            var entities = await context.CoffeeHouses
                .AsNoTracking()
                .Include(x => x.CoffeeItems)
                .ToListAsync()
                .ConfigureAwait(false);
            return _mapper.Map<IEnumerable<CoffeeHouse>>(entities);
        }
        public async Task<IEnumerable<CoffeeHouse>> GetAllAsync(string adminId)
        {
            using var context = _contextFactory.CreateDbContext(); //для работы с любыми данными юзать using

            var entities = await context.CoffeeHouses
                .AsNoTracking()
                .Include(x => x.CoffeeItems)
                .Where(x => x.CreatorId == adminId)
                .ToListAsync()
                .ConfigureAwait(false);
            return _mapper.Map<IEnumerable<CoffeeHouse>>(entities);
        }
        public async Task SellCoffeeItemAsync(string userId, int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var coffeeItem = await context.CoffeeItems
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);

            coffeeItem.SoldCounter++;

            context.CoffeeItems.Update(coffeeItem);
            await context.SaveChangesAsync().ConfigureAwait(false);

            var user = context.Users.First(u => u.Id == userId);
            context.OrderedCoffees.Add(new DAM.OrderedCoffee
            {
                CoffeeId = coffeeItem.Id,
                UserId = user.Id,
                Coffee = coffeeItem,
                User = user
            });

            await context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<CoffeeHouse>> GetPopularCoffeeHouses()
        {
            using var context = _contextFactory.CreateDbContext();
            var items = await context.CoffeeHouses
                .Include(x => x.CoffeeItems)
                .Where(x => x.CoffeeItems.Any(x => x.SoldCounter > 10))
                .OrderBy(x => x.Name)
                .Take(10)
                .ToListAsync()
                .ConfigureAwait(false);
            return _mapper.Map<IEnumerable<CoffeeHouse>>(items);
        }
    }
}
