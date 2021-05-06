
namespace Infrastructure.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int CoffeeHouseId { get; set; }
        public CoffeeHouse CoffeeHouse { get; set; }
    }
}
