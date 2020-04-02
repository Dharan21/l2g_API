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
        public CarResponse GetCars()
        {
            CarDL carDL = new CarDL();
            var cars = carDL.GetCars();
            if (cars == null)
                return null;
            CarResponse response = new CarResponse()
            {
                Count = cars.Count,
                Cars = cars
            };
            return response;
        }
    }
}
