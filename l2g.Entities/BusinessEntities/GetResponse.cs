﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class GetResponse
    {
        public int CarCount { get; set; }
        public List<CarVM> Cars { get; set; }
        public int BrandCount { get; set; }
        public List<BrandVM> Brands { get; set; }
        public int FuelTypeCount { get; set; }
        public List<FuelVM> fuelTypes { get; set; }
        public int GearBoxTypeCount { get; set; }
        public List<GearboxVM> gearBoxTypes { get; set; }
    }
}
