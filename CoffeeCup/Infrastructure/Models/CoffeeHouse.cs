using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class CoffeeHouse
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public AppUser Creator { get; set; }
        public ICollection<CoffeeItem> CoffeeItems { get; set; }
    }
}
