using AutoMapper;
using BusinessLogic.Models;

namespace BusinessLogic.Configs
{
    public class BusinessProfileMappingProfile : Profile
    {
        public BusinessProfileMappingProfile()
        {
            AppUser.CreateMaps(this);
            CoffeeHouse.CreateMaps(this);
            Favorite.CreateMaps(this);
            CoffeeItem.CreateMaps(this);
        }
    }
}
