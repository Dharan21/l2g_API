using l2g.DL.Mapping;
using l2g.Entities.BusinessEntities;
using l2g.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL
{
    public class CarDL
    {
        public List<CarVM> GetCars()
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                List<l2g_tbl_Car> cars = db.l2g_tbl_Car.ToList();
                if(cars.Count > 0)
                {
                    List<CarVM> carVMs = new List<CarVM>();
                    foreach (var car in cars)
                    {
                        carVMs.Add(MappingConfig.CarToBusinessEntity(car));
                    }
                    return carVMs;
                }
                return new List<CarVM>();
            }
        }

        public List<BrandVM> GetBrands()
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                List<l2g_tbl_Brand> brands = db.l2g_tbl_Brand.ToList();
                if (brands.Count > 0)
                {
                    List<BrandVM> brandVMs = new List<BrandVM>();
                    foreach (var brand in brands)
                    {
                        brandVMs.Add(MappingConfig.BrandToBusinessEntity(brand));
                    }
                    return brandVMs;
                }
                return new List<BrandVM>();
            }
        }

        public List<FuelVM> GetFuelTypes()
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                List<l2g_tbl_Fuel> fuelTypes = db.l2g_tbl_Fuel.ToList();
                if (fuelTypes.Count > 0)
                {
                    List<FuelVM> fuelVMs = new List<FuelVM>();
                    foreach (var fuelType in fuelTypes)
                    {
                        fuelVMs.Add(MappingConfig.FuelToBusinessEntity(fuelType));
                    }
                    return fuelVMs;
                }
                return new List<FuelVM>();
            }
        }

        public List<GearboxVM> GetGearboxTypes()
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                List<l2g_tbl_Gearbox> gearboxTypes = db.l2g_tbl_Gearbox.ToList();
                if (gearboxTypes.Count > 0)
                {
                    List<GearboxVM> gearboxVMs = new List<GearboxVM>();
                    foreach (var gearBoxType in gearboxTypes)
                    {
                        gearboxVMs.Add(MappingConfig.GearboxToBusinessEntity(gearBoxType));
                    }
                    return gearboxVMs;
                }
                return new List<GearboxVM>();
            }
        }
    }
}
