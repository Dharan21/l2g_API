using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class GetQuote
    {
        public int CarId { get; set; }
        public float Price { get; set; }
        public int MileageId { get; set; }
        public int MonthId { get; set; }
    }
}
