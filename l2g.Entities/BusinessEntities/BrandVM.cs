using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.Entities.BusinessEntities
{
    public class BrandVM
    { 
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
