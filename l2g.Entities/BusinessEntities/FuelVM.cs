using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class FuelVM
    {
        [Key]
        public int FuelId { get; set; }
        public string FuelType { get; set; }
    }
}
