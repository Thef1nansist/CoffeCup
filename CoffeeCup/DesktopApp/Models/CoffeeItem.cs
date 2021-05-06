namespace DesktopApp.Models
{
    public class CoffeeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CoffeeHouseId { get; set; }
        public CoffeeHouse CoffeeHouse { get; set; }
        public int SoldCounter { get; set; }
    }
}