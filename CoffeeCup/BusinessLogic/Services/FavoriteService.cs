using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAM = Infrastructure.Models;

namespace BusinessLogic.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IDbContextFactory<CoffeeCupContext> _contextFactory;
        private readonly IAppUserService _appUserService;

        private readonly IMapper _mapper;

        public FavoriteService(IDbContextFactory<CoffeeCupContext> contextFactory, IMapper mapper, UserManager<DAM.AppUser> userManager, IAppUserService appUserService)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        public async Task<Favorite> AddAsync(Favorite item)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var addModel = _mapper.Map<DAM.Favorite>(item);
                var entityDa = await context.Favorites
                    .AddAsync(addModel)
                    .ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return _mapper.Map<Favorite>(entityDa.Entity);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }

        public async Task<Favorite> UpdateAsync(Favorite item)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.Favorites
                .FirstOrDefaultAsync(i => i.Id == item.Id)
                .ConfigureAwait(false);

            if (entity != null)
            {
                var itemNew = _mapper.Map(item, entity);

                context.Favorites.Update(itemNew);
            }

            return _mapper.Map<Favorite>(entity);
        }

        public async Task<Favorite> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.Favorites
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id)
                .ConfigureAwait(false);

            return _mapper.Map<Favorite>(entity);
        }
        public async Task<IEnumerable<Favorite>> GetByUserId(string userId)
        {
            using var context = _contextFactory.CreateDbContext();

            var entities = await context.Favorites
                .Where(item => item.UserId == userId)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<Favorite>>(entities);
        }
        public async Task<IEnumerable<Favorite>> GetByCoffeHouseId(int coffeHouseId)
        {
            using var context = _contextFactory.CreateDbContext();

            var entities = await context.Favorites
                .Where(item => item.CoffeeHouseId == coffeHouseId)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<Favorite>>(entities);
        }

        public async Task<IEnumerable<Favorite>> GetAll(string userId)
        {
            using var context = _contextFactory.CreateDbContext();

            var entities = await context.Favorites
                .AsNoTracking()
                .Include(x => x.CoffeeHouse)
                .Where(x => x.UserId == userId)
                .ToListAsync()
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<Favorite>>(entities);
        }
       
        public IEnumerable<Infrastructure.Models.OrderedCoffee> GetOrderedCoffee(string userId)
        {
            using var context = _contextFactory.CreateDbContext();
            var items = context.OrderedCoffees
                .Include(x => x.Coffee)
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Id)
                .ToList();

            return items;
        }

        public async Task<bool> GetSameFavoritesCoffeeHouses(string userId, int CoffeeHouseId)
        {
            using var context = _contextFactory.CreateDbContext();
            var items = await context.Favorites
                .Where(x => x.UserId == userId)
                .Where(x => x.CoffeeHouseId == CoffeeHouseId)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
            return items.Count > 0;
        }
    }
}
