﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class OrderedCoffee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CoffeeId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual CoffeeItem Coffee { get; set; }
    }
}
