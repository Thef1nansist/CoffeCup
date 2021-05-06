using AutoMapper;
using DA = Infrastructure.Models;

namespace BusinessLogic.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int CoffeeHouseId { get; set; }
        public CoffeeHouse CoffeeHouse { get; set; }

        public static void CreateMaps(Profile profile)
        {
            profile.CreateMap<DA.Favorite, Favorite>()
                .ReverseMap();
        }
    }
}
