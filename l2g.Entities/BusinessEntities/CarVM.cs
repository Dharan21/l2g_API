using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class CarVM
    {
        [Key]
        public int CarId { get; set; }
        public BrandVM Brand { get; set; }
        public FuelVM Fuel { get; set; }
        public GearboxVM Gearbox { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public float CO2Emission { get; set; }
    }
}
