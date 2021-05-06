using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DA = Infrastructure.Models;

namespace BusinessLogic.Models
{
    public class CoffeeHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<CoffeeItem> CoffeeItems{ get; set; }
        internal static void CreateMaps(Profile profile)
        {
            profile.CreateMap<DA.CoffeeHouse, CoffeeHouse>()
                .ForMember(x => x.CoffeeItems, opt => opt.MapFrom(s => s.CoffeeItems))
                .ReverseMap()
                .ForMember(d => d.CoffeeItems, opt => opt.MapFrom(s => s.CoffeeItems.ToList()));
                
        }
    }
}
