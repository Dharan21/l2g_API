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
    }
}
