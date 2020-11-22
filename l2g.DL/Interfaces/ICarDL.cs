using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL.Interfaces
{
    public interface ICarDL
    {
        bool CarExists(int carId);
        List<CarVM> GetCars();
        List<BrandVM> GetBrands();
        List<FuelVM> GetFuelTypes();
        List<GearboxVM> GetGearboxTypes();
        List<MileageVM> GetMileages();
        List<PaybackTimeVM> GetPaybackTimes();
}
}
