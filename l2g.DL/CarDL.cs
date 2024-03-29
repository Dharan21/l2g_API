﻿using l2g.DL.Interfaces;
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
    public class CarDL : ICarDL
    {
        public bool CarExists(int carId)
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                return db.l2g_tbl_Car.Any(x => x.CarId == carId);
            }
        }
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

        public List<MileageVM> GetMileages()
        {
            using(var db = new Lead2OrderGenerateDbEntities())
            {
                List<l2g_tbl_Mileage> mileages = db.l2g_tbl_Mileage.ToList();
                if(mileages.Count > 0)
                {
                    List<MileageVM> mileageVMs = new List<MileageVM>();
                    foreach (var mileage in mileages)
                    {
                        mileageVMs.Add(MappingConfig.MileageToBusinessEntity(mileage));
                    }
                    return mileageVMs;
                }
            }
            return new List<MileageVM>();
        }

        public List<PaybackTimeVM> GetPaybackTimes()
        {
            using (var db = new Lead2OrderGenerateDbEntities())
            {
                List<l2g_tbl_PaybackTime> paybackTimes = db.l2g_tbl_PaybackTime.ToList();
                if (paybackTimes.Count > 0)
                {
                    List<PaybackTimeVM> paybackTimeVMs = new List<PaybackTimeVM>();
                    foreach (var paybackTime in paybackTimes)
                    {
                        paybackTimeVMs.Add(MappingConfig.paybackTimeToBusinessEntity(paybackTime));
                    }
                    return paybackTimeVMs;
                }
            }
            return new List<PaybackTimeVM>();
        }
    }
}
