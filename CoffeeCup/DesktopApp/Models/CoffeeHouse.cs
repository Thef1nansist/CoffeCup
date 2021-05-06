using System.Collections.Generic;

namespace DesktopApp.Models
{
    public class CoffeeHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<CoffeeItem> CoffeeItems { get; set; }
    }
}