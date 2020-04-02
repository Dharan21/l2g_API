using l2g.DL;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL
{
    public class CarBL
    {
        public GetResponse GetCars()
        {
            CarDL carDL = new CarDL();
            var cars = carDL.GetCars();
            var brands = carDL.GetBrands();
            var fuelTypes = carDL.GetFuelTypes();
            var gearBoxTypes = carDL.GetGearboxTypes();
            if (cars == null && brands == null && fuelTypes == null && gearBoxTypes == null)
                return null;
            GetResponse response = new GetResponse()
            {
                CarCount = cars.Count,
                Cars = cars,
                BrandCount = brands.Count,
                Brands = brands,
                FuelTypeCount = fuelTypes.Count,
                fuelTypes = fuelTypes,
                GearBoxTypeCount = gearBoxTypes.Count,
                gearBoxTypes = gearBoxTypes
            };
            return response;
        }
    }
}
