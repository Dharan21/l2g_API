using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class ConfirmQuote
    {
        public UserDetailsFullVM User { get; set; }
        public CarVM Car { get; set; }
        public MileageVM Mileage { get; set; }
        public PaybackTimeVM PaybackTime { get; set; }
        public float Price { get; set; }
    }
}
