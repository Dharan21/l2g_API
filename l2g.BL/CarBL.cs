using l2g.BL.Interfaces;
using l2g.DL;
using l2g.DL.Interfaces;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL
{
    public class CarBL: ICarBL
    {
        private ICarDL _carDL;

        public CarBL(ICarDL carDL)
        {
            _carDL = carDL;
        }
        public GetResponse GetCars()
        {
            var cars = _carDL.GetCars();
            var brands = _carDL.GetBrands();
            var fuelTypes = _carDL.GetFuelTypes();
            var gearBoxTypes = _carDL.GetGearboxTypes();
            var mileages = _carDL.GetMileages();
            var paybackTimes = _carDL.GetPaybackTimes();
            if (cars == null && brands == null && fuelTypes == null && gearBoxTypes == null && mileages == null && paybackTimes == null)
                return null;
            GetResponse response = new GetResponse()
            {
                CarCount = cars.Count,
                Cars = cars,
                BrandCount = brands.Count,
                Brands = brands,
                FuelTypeCount = fuelTypes.Count,
                FuelTypes = fuelTypes,
                GearBoxTypeCount = gearBoxTypes.Count,
                GearBoxTypes = gearBoxTypes,
                MileageCount = mileages.Count,
                Mileages = mileages,
                PaybackTimeCount = paybackTimes.Count,
                PaybackTimes = paybackTimes
            };
            return response;
        }
    }
}
