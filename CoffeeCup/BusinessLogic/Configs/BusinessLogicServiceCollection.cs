using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Configs
{
    public static class BusinessLogicServiceCollection
    {
        public static IServiceCollection AddBusinessLogicServiceCollection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppUserService), typeof(AppUserService));
            services.AddScoped(typeof(ICoffeeHouseService), typeof(CoffeeHouseService));
            services.AddScoped(typeof(IFavoriteService), typeof(FavoriteService));


            services.AddAutoMapper(typeof(BusinessProfileMappingProfile));


            return services;
        }
    }
}
