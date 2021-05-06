using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
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
