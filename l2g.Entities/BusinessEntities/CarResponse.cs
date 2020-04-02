using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class CarResponse
    {
        public int Count { get; set; }
        public List<CarVM> Cars { get; set; }
    }
}
