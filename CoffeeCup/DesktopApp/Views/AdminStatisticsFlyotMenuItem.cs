﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    public class AdminStatisticsFlyotMenuItem
    {
        public AdminStatisticsFlyotMenuItem()
        {

            TargetType = typeof(AdminStatisticsFlyotMenuItem);
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
