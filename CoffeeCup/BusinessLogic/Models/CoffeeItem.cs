using AutoMapper;
using DA = Infrastructure.Models;


namespace BusinessLogic.Models
{
    public class CoffeeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CoffeeHouseId { get; set; }
        public CoffeeHouse CoffeeHouse { get; set; }
        public int SoldCounter { get; set; }

        public static void CreateMaps(Profile profile)
        {
            profile.CreateMap<DA.CoffeeItem, CoffeeItem>()
                .ReverseMap();
        }
    }
}
